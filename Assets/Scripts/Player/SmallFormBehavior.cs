using UnityEngine;
using UnityEngine.InputSystem;

public class SmallFormBehavior : MonoBehaviour, IInteract
{
    bool canMoveObject;
    bool objectDetected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectDetected = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractWithObject()
    {
        if (canMoveObject)
        {
            Debug.Log("Big Form interaction");
        }

        else if (objectDetected && !canMoveObject)
        {
            Debug.Log("Object too big 5 me");
        }

        else { return; }

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MovableObject")
        {
            objectDetected = true;
            ObjectPickup objectToPickup = collision.GetComponent<ObjectPickup>();
            canMoveObject = objectToPickup.AbleToPickUp;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MovableObject")
        {
            canMoveObject = false;
            objectDetected = false;
        }
    }
}
