using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance { get; private set; }

    public GameObject tooltipPrefab;
    private GameObject currentTooltip;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ShowTooltip(TooltipData data, Vector3 worldPosition)
    {
        if (currentTooltip != null) Destroy(currentTooltip);

        currentTooltip = Instantiate(tooltipPrefab, worldPosition + Vector3.up * 1.5f, Quaternion.identity);
        currentTooltip.GetComponentInChildren<TMP_Text>().text = data.tooltipText;
    }

    public void HideTooltip()
    {
        if (currentTooltip != null)
            Destroy(currentTooltip);
    }
}
