using UnityEngine;

public class TooltipDetectionLarge : MonoBehaviour
{
    [SerializeField] private TooltipData tooltipData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BigFormHitbox") && tooltipData != null)
        {
            TooltipManager.Instance.ShowTooltip(tooltipData.tooltipText);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BigFormHitbox"))
        {
            TooltipManager.Instance.HideTooltip();
        }
    }
}
