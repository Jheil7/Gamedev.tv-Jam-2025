using UnityEngine;

public class FootstepAudioRelay : MonoBehaviour
{
    public PlayerAudio audioController;

    public void PlayFootstep()
    {
        audioController.PlayFootstep();
    }

    public void PlayJump()
    {
        audioController.PlayJump();
    }
}
