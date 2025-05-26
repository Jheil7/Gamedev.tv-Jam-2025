using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EndGame : MonoBehaviour
{
    [SerializeField] private ScreenFader2 screenFader2;
    [SerializeField] private EndScreenFader endScreenFader;
    [SerializeField] private PlayerMovement playerMove;
    [SerializeField] private Transform plantSeedPos;
    [SerializeField] private GameObject bucket;
    [SerializeField] private GameObject oldTree;
    [SerializeField] private GameObject rope;
    [SerializeField] private GameObject seed;
    [SerializeField] private GameObject finalSeedHome;
    [SerializeField] private Transform playerPos;

    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Seed"))
        {
            hasTriggered = true;
            StartCoroutine(FinalCutsceneSequence(other.transform));
        }
    }

    private IEnumerator FinalCutsceneSequence(Transform seedTransform)
    {
        // Fade to black (2 seconds)
        yield return screenFader2.FadeOut(2.0f);

        // Move and update scene
        playerPos.position = plantSeedPos.position;
        playerMove.enabled = false;
        bucket.SetActive(false);
        rope.SetActive(false);
        oldTree.SetActive(false);
        seed.SetActive(false);
        finalSeedHome.SetActive(true);

        // Fade in (10 seconds)
        yield return screenFader2.FadeIn(10f);

        // Short pause before final end fade
        yield return new WaitForSeconds(1f);

        // Fade to black + show "The End"
        endScreenFader.TriggerEndScreen();
    }
}
