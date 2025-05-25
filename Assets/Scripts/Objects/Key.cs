using System.Collections;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameStateManager gameState;
    public TooltipData tooltipData;
    public float seconds;
    SpriteRenderer spriteRenderer;
    public GameObject lockedShed;
    public GameObject unlockedShedClosed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallFormHitbox")
        {
            gameState.keyAcquired = true;
            StartCoroutine(BriefToolTip());
            spriteRenderer.enabled = false;
            lockedShed.SetActive(false);
            unlockedShedClosed.SetActive(true);
        }
    }

    IEnumerator BriefToolTip()
    {
        TooltipManager.Instance.ShowTooltip(tooltipData.tooltipText);
        yield return new WaitForSeconds(seconds);
        TooltipManager.Instance.HideTooltip();
    }
}
