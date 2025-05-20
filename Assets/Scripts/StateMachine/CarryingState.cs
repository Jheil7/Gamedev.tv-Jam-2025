// using UnityEngine;

// public class CarryingState : InteractionState
// {
//     public CarryingState(BigFormBehavior context) : base(context) { }

//     public override void Enter()
//     {
//         context.carryingObject = true;
//         context.objectBeingHeld = context.objectToPickup.gameObject;

//         var rb = context.objectBeingHeld.GetComponent<Rigidbody2D>();
//         if (rb != null)
//         {
//             rb.bodyType = RigidbodyType2D.Kinematic;
//             rb.linearVelocity = Vector2.zero;
//         }
//         var collider = context.objectBeingHeld.GetComponent<Collider2D>();
//         if (collider != null)
//         {
//             collider.enabled = false;
//         }
//     }

//     public override void Update()
//     {

//             context.objectBeingHeld.transform.position = context.playerHands.position;

//     }

//     public override void Interact()
//     {
//         if (context.objectBeingHeld != null)
//         {
//             var rb = context.objectBeingHeld.GetComponent<Rigidbody2D>();
//             if (rb != null)
//             {
//                 rb.bodyType = RigidbodyType2D.Dynamic;
//             }

//             var collider = context.objectBeingHeld.GetComponent<Collider2D>();
//             if (collider != null)
//             {
//                 collider.enabled = true;
//             }

//             context.objectBeingHeld = null;
//             context.carryingObject = false;
//             context.TransitionToState(new IdleState(context));
//         }
//     }
// }
