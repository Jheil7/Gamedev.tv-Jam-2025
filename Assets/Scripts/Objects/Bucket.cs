using UnityEngine;
using UnityEngine.InputSystem;

public class Bucket : MonoBehaviour, InteractF
{
    GameObject player;
    public Transform exitPoint;
    public Transform bucketSeatPoint;
    public GameObject wellGameObject;
    bool isAtTop;

    public void InteractWithObjectF()
    {
        Debug.Log("you get in the bucket");
        player.transform.position = bucketSeatPoint.position;
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
