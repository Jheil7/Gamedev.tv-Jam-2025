using UnityEngine;

public class TurnoffBigFormTrigger : MonoBehaviour
{
    private FormSwap formSwap;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallFormHitbox")
        {
            formSwap = collision.GetComponentInParent<FormSwap>();
            formSwap.BigFormUnlocked = false;
        }

        //turn into small form if already in big form
        if (collision.tag == "BigFormHitbox")
        {
            formSwap = collision.GetComponentInParent<FormSwap>();
            formSwap.SetActiveForm(0);
            formSwap.SwitchToZoomedIn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "SmallFormHitbox")
        {
            formSwap = collision.GetComponentInParent<FormSwap>();
            formSwap.BigFormUnlocked = true;
        }
    }
}
