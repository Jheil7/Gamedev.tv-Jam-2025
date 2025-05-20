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
        if (collision.tag == "BigFormHitbox")
        {
            ableToPickUp = true;
            //do pickup
        }

        else if (collision.tag == "SmallFormHitbox")
        {
            ableToPickUp = true;
            //cant be picked up, too small
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BigFormHitbox" || collision.tag == "SmallFormHitbox")
        {
            ableToPickUp = false;
        }
    }
}
