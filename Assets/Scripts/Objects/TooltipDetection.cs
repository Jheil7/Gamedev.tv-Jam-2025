using UnityEngine;

public class TooltipDetection : MonoBehaviour
{
    public TooltipData tooltipData;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TooltipManager.Instance.ShowTooltip(tooltipData, transform.position);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TooltipManager.Instance.HideTooltip();
        }
    }
}
