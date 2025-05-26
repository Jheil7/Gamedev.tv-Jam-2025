using UnityEngine;

public class CatchSeed : MonoBehaviour
{
    public Transform seedSpawnPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Seed"))
        {
            other.transform.position = seedSpawnPos.position;
        }
    }
}
