using System.Collections;
using UnityEngine;

public class EndScreenFader : MonoBehaviour
{
    //[SerializeField] private CanvasGroup fadeGroup;
    [SerializeField] private GameObject theEndText;
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private float delayBeforeText = 1f;

    void Start()
    {
        //fadeGroup.alpha = 0f;
        theEndText.SetActive(false);
    }

    public void TriggerEndScreen()
    {
        StartCoroutine(FadeToEnd());
    }

    private IEnumerator FadeToEnd()
    {
        //float t = 0f;
        //while (t < fadeDuration)
        //{
        //    t += Time.deltaTime;
        //    fadeGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
        //    yield return null;
        //}

        //fadeGroup.alpha = 1f;

        yield return new WaitForSeconds(delayBeforeText);
        theEndText.SetActive(true);
        Animator animator = theEndText.GetComponent<Animator>();
        animator.Play("logo");
        animator.StopPlayback();
    }
}
