using UnityEngine;
using UnityEngine.InputSystem;

public class BigFormBehavior : MonoBehaviour, IInteract
{
    bool canMoveObject;
    private ObjectPickup objectToPickup;
    [SerializeField] Transform playerHands;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractWithObject()
    {
        if (canMoveObject)
        {
            Transform objectTransform = objectToPickup.transform;
            objectTransform.position = playerHands.position;
            Debug.Log("Picking up object");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MovableObject")
        {
            objectToPickup = collision.GetComponent<ObjectPickup>();
            canMoveObject = objectToPickup.AbleToPickUp;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MovableObject")
        {
            canMoveObject = false;
        }
    }

    void HoldObjectInHands()
    {

    }

    void DropObject()
    { 
        
    }
}
