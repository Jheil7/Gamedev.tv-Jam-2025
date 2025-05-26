using UnityEngine;

public class ObjectDebugReporter : MonoBehaviour
{
    void Awake()
    {
        Debug.Log($"[AWAKE] {name}: tag = {tag}, layer = {LayerMask.LayerToName(gameObject.layer)}");

        Collider2D col = GetComponent<Collider2D>();
        Debug.Log($"[AWAKE] Collider2D found: {col != null}, isTrigger = {col?.isTrigger}");

        var pickupScript = GetComponent<ObjectPickup>(); // replace with actual script
        Debug.Log($"[AWAKE] PickupScript attached: {pickupScript != null}");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[TRIGGER] {name} triggered by {other.name} with tag {other.tag}");
    }
}
