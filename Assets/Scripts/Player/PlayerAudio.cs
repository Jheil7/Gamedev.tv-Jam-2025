using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public enum PlayerForm { Small, Big }
    public PlayerForm currentForm;

    public AudioSource audioSource;

    public AudioClip smallFootstep;
    public AudioClip bigFootstep;
    // public AudioClip smallJump;
    // public AudioClip bigJump;

    public void SetForm(PlayerForm form)
    {
        currentForm = form;
    }

    public void PlayFootstep()
    {
        AudioClip clip = currentForm == PlayerForm.Small ? smallFootstep : bigFootstep;
        audioSource.PlayOneShot(clip);
    }

    public void PlayJump()
    {
        // AudioClip clip = currentForm == PlayerForm.Small ? smallJump : bigJump;
        // audioSource.PlayOneShot(clip);
    }
}
