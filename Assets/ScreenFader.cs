using System.Collections;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeGroup;
    [SerializeField] private float fadeDuration = 1f;

    void Start()
    {
        fadeGroup.alpha = 0f;
    }

    public IEnumerator FadeOutIn(System.Action onMiddle)
    {
        yield return Fade(1f);      // Fade to black
        onMiddle?.Invoke();         // Move the player
        yield return Fade(0f);      // Fade back in
    }

    private IEnumerator Fade(float target)
    {
        float start = fadeGroup.alpha;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(start, target, t / fadeDuration);
            yield return null;
        }

        fadeGroup.alpha = target;
    }

    public IEnumerator FadeOut()
    {
        yield return StartCoroutine(Fade(1f));
    }

    public IEnumerator FadeIn()
    {
        yield return StartCoroutine(Fade(0f));
    }
}
