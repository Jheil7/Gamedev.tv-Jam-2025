using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public bool ableToPickUp;

    public bool AbleToPickUp
    {
        get { return ableToPickUp; }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigFormHitbox"))
        {
            ableToPickUp = true;
            //do pickup
        }

        else if (collision.CompareTag("SmallFormHitbox") )
        {
            ableToPickUp = true;
            //cant be picked up, too small
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BigFormHitbox") || collision.CompareTag("SmallFormHitbox") )
        {
            ableToPickUp = false;
        }
    }
}
