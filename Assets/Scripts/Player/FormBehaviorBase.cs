using UnityEngine;
using UnityEngine.InputSystem;

public abstract class FormBehaviorBase : MonoBehaviour, IInteract, InteractF
{
    protected enum CarryState
    {
        Idle,
        ReadyToPickup,
        Carrying
    }

    [SerializeField] protected Transform playerHands;
    [SerializeField] protected string targetTag = "MovableSmall";
    [SerializeField] protected Animator animator;

    protected ObjectPickup objectToPickup;
    protected GameObject objectBeingHeld;
    protected Rigidbody2D objectRb;
    protected Collider2D objectCol;

    protected CarryState currentState = CarryState.Idle;

    protected InteractF nearbyFInteractable;

    protected virtual void Update()
    {
        if (currentState == CarryState.Carrying && objectBeingHeld != null)
        {
            objectBeingHeld.transform.position = playerHands.position;
        }
    }

    public virtual void InteractWithObject()
    {
        animator.Play("GrandyeGrabAnim");
        animator.StopPlayback();
        switch (currentState)
        {
            case CarryState.ReadyToPickup:
                if (objectToPickup != null && objectToPickup.AbleToPickUp)
                {
                    animator.SetBool("hasObject", true);
                    PickUpObject();
                }
                break;

            case CarryState.Carrying:
                animator.SetBool("hasObject", false);
                DropObject();
                break;

            default:
                // Do nothing in Idle
                break;
        }
    }

    public void InteractWithObjectF()
    {
        if (nearbyFInteractable != null)
        {
            nearbyFInteractable.InteractWithObjectF();
        }
    }

    protected virtual void PickUpObject()
    {
        objectBeingHeld = objectToPickup.gameObject;
        objectRb = objectBeingHeld.GetComponent<Rigidbody2D>();
        objectCol = objectBeingHeld.GetComponent<Collider2D>();

        if (objectRb != null)
        {
            objectRb.linearVelocity = Vector2.zero;
            objectRb.bodyType = RigidbodyType2D.Kinematic;
        }

        if (objectCol != null)
        {
            objectCol.enabled = false;
        }

        currentState = CarryState.Carrying;
        Debug.Log($"Picked up: {objectBeingHeld.name}");
    }

    protected virtual void DropObject()
    {
        if (objectBeingHeld != null)
        {
            if (objectRb != null) objectRb.bodyType = RigidbodyType2D.Dynamic;
            if (objectCol != null) objectCol.enabled = true;

            objectBeingHeld.transform.SetParent(null);
            objectBeingHeld = null;
            objectRb = null;
            objectCol = null;
        }

        currentState = CarryState.Idle;
        Debug.Log("Dropped object");
    }

    public void ForceDropIfCarrying()
    {
        if (currentState == CarryState.Carrying)
        {
            DropObject();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            objectToPickup = collision.GetComponent<ObjectPickup>();
            if (objectToPickup != null && objectToPickup.AbleToPickUp && currentState == CarryState.Idle)
            {
                currentState = CarryState.ReadyToPickup;
            }
        }

        if (collision.TryGetComponent(out InteractF interactF))
        {
            nearbyFInteractable = interactF;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag) &&
            objectToPickup != null &&
            collision.gameObject == objectToPickup.gameObject)
        {
            objectToPickup = null;

            if (currentState == CarryState.ReadyToPickup)
            {
                currentState = CarryState.Idle;
            }
        }

        if (collision.TryGetComponent(out InteractF interactF) &&
        interactF == nearbyFInteractable)
        {
            nearbyFInteractable = null;
        }
    }
}

