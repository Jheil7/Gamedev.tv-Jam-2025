using UnityEngine;

public class PrefabDebugReporter : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"[DEBUG] {name} initialized.");
        
        var col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogWarning($"{name} is missing a Collider2D!");
        }
        else
        {
            Debug.Log($"[DEBUG] {name} collider: enabled={col.enabled}, isTrigger={col.isTrigger}");
        }

        Debug.Log($"[DEBUG] Layer: {gameObject.layer} ({LayerMask.LayerToName(gameObject.layer)})");

        var pickupScript = GetComponent<FormBehaviorBase>(); // Replace with your actual script name
        if (pickupScript == null)
        {
            Debug.LogWarning($"{name} is missing the pickup script!");
        }
        else
        {
            Debug.Log($"[DEBUG] {name} has pickup script assigned.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[TRIGGER] {name} was entered by {other.name} on layer {LayerMask.LayerToName(other.gameObject.layer)}");
    }
}
