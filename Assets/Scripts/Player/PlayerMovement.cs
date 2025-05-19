using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Jump Variables")]
    [SerializeField] float jumpHeight;
    [SerializeField] private float jumpBufferTime = 0.1f;
    [SerializeField] private float coyoteTime = 0.1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    public bool hasJumpedThisFrame=false;
    [SerializeField] LayerMask groundLayer;
    private float jumpBufferCounter;
    private float coyoteTimeCounter;
    public bool isGrounded;
    [SerializeField] float playerMoveSpeed;
    Rigidbody2D playerRb;
    Vector2 rawInput;
    private bool facingLeft;
    




    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();
        Jump();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnMove(InputValue value){
        rawInput=value.Get<Vector2>();
        if(rawInput.x > 0 && facingLeft) Flip();
        if(rawInput.x < 0 && !facingLeft) Flip();
    }

    void PlayerMove()
    {
        Vector2 delta = rawInput * playerMoveSpeed;
        playerRb.linearVelocity = new Vector2(delta.x, playerRb.linearVelocityY);
        // if(delta.x != 0) animator.SetFloat("speed", 1f);
        // else animator.SetFloat("speed", 0f);            
    }

    void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }

    void Jump()
    {
        CheckGrounding();
        if (hasJumpedThisFrame)
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            Vector2 jumpVector = new Vector2(playerRb.linearVelocityX, jumpHeight);
            //set y velocity to 0 to counter gravity
            playerRb.linearVelocity = new Vector2(playerMoveSpeed, 0);
            playerRb.AddForce(jumpVector, ForceMode2D.Impulse);

            isGrounded = false;
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
            hasJumpedThisFrame = true;
        }
    }

    void CheckGrounding()
    { 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;
    }
    void LateUpdate()
    {
        hasJumpedThisFrame = false;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
