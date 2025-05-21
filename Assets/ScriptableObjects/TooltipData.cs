using UnityEngine;

[CreateAssetMenu(fileName = "New Tooltip", menuName = "Tooltips/Tooltip Data")]
public class TooltipData : ScriptableObject
{
    [TextArea]
    public string tooltipText;
}
