using Unity.VisualScripting;
using UnityEngine;

public class TeleportOutofLock : MonoBehaviour
{
    [SerializeField] Transform doorLockPosition;
    [SerializeField] private ScreenFader screenFader;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BigFormHitbox"|| other.tag=="SmallFormHitbox")
        {
            StartCoroutine(screenFader.FadeOutIn(() =>
            {
                other.transform.root.position = doorLockPosition.position;
            }));
        }
    }
}
