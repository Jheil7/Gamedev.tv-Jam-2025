using System.Collections;
using UnityEngine;

public class ScreenFader2 : MonoBehaviour

{
    
[SerializeField] private CanvasGroup fadeGroup;
public IEnumerator FadeOut(float duration)
    {
        yield return StartCoroutine(Fade(1f, duration));
    }

public IEnumerator FadeIn(float duration)
{
    yield return StartCoroutine(Fade(0f, duration));
}

private IEnumerator Fade(float targetAlpha, float duration)
{
    float startAlpha = fadeGroup.alpha;
    float time = 0f;

    while (time < duration)
    {
        time += Time.deltaTime;
        fadeGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
        yield return null;
    }

    fadeGroup.alpha = targetAlpha;
}

}
