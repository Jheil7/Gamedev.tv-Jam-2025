using UnityEngine;
using UnityEngine.InputSystem;

public class Bucket : MonoBehaviour, InteractF
{
    GameObject player;
    public Transform exitPoint;
    public Transform bucketSeatPoint;
    public GameObject wellGameObject;
    bool isAtTop;
    bool canGetIn=true;

    public void InteractWithObjectF()
    {
        if (canGetIn)
        { 
            player.transform.position = bucketSeatPoint.position;
        }
        
        player.GetComponentInParent<PlayerInput>().enabled = false;
        if (!isAtTop)
        {
            GetComponent<Animator>().SetTrigger("StartLift");
            isAtTop = true;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("LowerBucket");
            isAtTop = false;
        }

    }

    public void FinishLift()
    {
        if (player != null)
        {
            player.GetComponentInParent<PlayerInput>().enabled = true;
            player = null;
        }

        this.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallFormHitbox")
        {
            player = collision.transform.root.gameObject;
            canGetIn = true;
        }
        else if (collision.tag == "BigFormHitbox")
        {
            canGetIn=false;
        }
    }

    public void TurnOnCollider()
    {
        Collider2D wellCollider = wellGameObject.GetComponent<Collider2D>();
        wellCollider.enabled = true;
    }

    public void TurnOffCollider()
    {
        Collider2D wellCollider = wellGameObject.GetComponent<Collider2D>();
        wellCollider.enabled = false;
    }
}
