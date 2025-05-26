using UnityEngine;

public class Tumbler : MonoBehaviour
{
    public int tumblerID;
    public Transform tumblerHead;
    public Vector3 upPositionOffset = new Vector3(0f, 0.3f, 0f);
    private Vector3 initialPosition;


    private void Start()
    {
        if (tumblerHead != null)
            initialPosition = tumblerHead.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SmallFormHitbox"))
        {
            LockManager.Instance.TumblerHit(tumblerID, this);
        }
    }

    public void PopUp()
    {
        if (tumblerHead != null)
            tumblerHead.localPosition = initialPosition + upPositionOffset;
    }

    public void ResetPosition()
    {
        if (tumblerHead != null)
            tumblerHead.localPosition = initialPosition;
    }
}