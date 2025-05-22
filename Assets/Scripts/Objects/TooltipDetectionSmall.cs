using UnityEngine;

public class TooltipDetectionSmall : MonoBehaviour
{
    [SerializeField] private TooltipData tooltipData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SmallFormHitbox") && tooltipData != null)
        {
            TooltipManager.Instance.ShowTooltip(tooltipData.tooltipText);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SmallFormHitbox"))
        {
            TooltipManager.Instance.HideTooltip();
        }
    }
}
