using UnityEngine;

public class CatShed : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 40f;
    [SerializeField] private float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
