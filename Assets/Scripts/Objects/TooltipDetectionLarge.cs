using UnityEngine;

public class TooltipDetectionLarge : MonoBehaviour
{
    public TooltipData tooltipData;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SmallFormHitbox"))
        {
            TooltipManager.Instance.ShowTooltip(tooltipData, transform.position);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SmallFormHitBox"))
        {
            TooltipManager.Instance.HideTooltip();
        }
    }
}
