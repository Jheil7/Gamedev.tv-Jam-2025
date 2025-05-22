using UnityEngine;

public class TeleportOutofLock : MonoBehaviour
{
    [SerializeField] Transform doorLockPosition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SmallFormHitbox")
        {
            other.transform.root.position = doorLockPosition.position;
        }
    }
}
