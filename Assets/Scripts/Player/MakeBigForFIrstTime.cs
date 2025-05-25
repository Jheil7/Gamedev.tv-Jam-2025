using System.Collections;
using UnityEngine;

public class MakeBigForFIrstTime : MonoBehaviour
{
    BoxCollider2D thisBoxCollider;
    [SerializeField] private TooltipData tooltipData;
    [SerializeField] float seconds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallFormHitbox")
        {
            FormSwap playerForm = collision.GetComponentInParent<FormSwap>();
            playerForm.SetActiveForm(1);
            playerForm.SwitchToZoomedOut();
            StartCoroutine(BriefToolTip());
            thisBoxCollider.enabled = false;

        }
    }

    IEnumerator BriefToolTip()
    {
        TooltipManager.Instance.ShowTooltip(tooltipData.tooltipText);
        yield return new WaitForSeconds(seconds);
        TooltipManager.Instance.HideTooltip();
    }
}
