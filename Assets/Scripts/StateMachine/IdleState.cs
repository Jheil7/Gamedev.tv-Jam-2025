// using UnityEngine;

// public class IdleState : InteractionState
// {
//     public IdleState(BigFormBehavior context) : base(context) { }

//     public override void Enter()
//     {
//         context.canMoveObject = false;
//         context.objectToPickup = null;
//     }

//     public override void Interact()
//     {
//         if (context.objectToPickup != null && context.objectToPickup.AbleToPickUp)
//         {
//             context.TransitionToState(new CarryingState(context));
//         }
//     }
// }
