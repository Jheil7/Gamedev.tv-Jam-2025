// using UnityEngine;

// public class ReadyToPickupState : InteractionState
// {
//     public ReadyToPickupState(BigFormBehavior context) : base(context) { }

//     public override void Enter()
//     {
//         context.canMoveObject = true;
//     }

//     public override void Interact()
//     {
//     Debug.Log("ReadyToPickupState.Interact() called");

//     if (context.objectToPickup == null)
//     {
//         Debug.LogWarning("objectToPickup is null in ReadyToPickupState");
//         return;
//     }

//     if (!context.objectToPickup.AbleToPickUp)
//     {
//         Debug.LogWarning("objectToPickup.AbleToPickUp is false");
//         return;
//     }

//     Debug.Log("Transitioning to CarryingState");
//     context.TransitionToState(new CarryingState(context));
//     }
// }
