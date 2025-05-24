using System.Collections;
using UnityEngine;

public class ShakeOnTrigger : MonoBehaviour
{
    public float shakeDuration = 2f;         // How long the player must stay to fall
    public float shakeMagnitude = 0.05f;     // How strong the shake is
    public float shakeSpeed = 20f;           // How fast it shakes

    public float timer = 0f;
    private Vector3 originalPos;
    private Collider2D col;
    public float colliderResetDelay = 3f;

    void Start()
    {
        originalPos = transform.localPosition;
        col = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BigFormHitbox"))
        {
            col.enabled = false;
            StartCoroutine(ReenableColliderAfterDelay());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SmallFormHitbox") || other.CompareTag("BigFormHitbox"))
        {
            timer = 0f;
            transform.localPosition = originalPos;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("SmallFormHitbox"))
        {
            timer += Time.deltaTime;

            // Shake effect
            float x = Mathf.Sin(Time.time * shakeSpeed) * shakeMagnitude;
            float y = Mathf.Cos(Time.time * shakeSpeed) * shakeMagnitude;
            transform.localPosition = originalPos + new Vector3(x, y, 0);

            if (timer >= shakeDuration)
            {
                col.enabled = false; // Make player fall
                transform.localPosition = originalPos; // Reset position
                StartCoroutine(ReenableColliderAfterDelay());
                enabled = false; // Stop script if needed
            }
        }
    }
    
    IEnumerator ReenableColliderAfterDelay()
    {
        yield return new WaitForSeconds(colliderResetDelay);
        col.enabled = true;
    }
}