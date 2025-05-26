using UnityEngine;
using UnityEngine.UIElements;

public class CupTransformReset : MonoBehaviour
{
    [SerializeField] private float maxDistance = 1000f;
    private Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, startingPos);
        if (distance > maxDistance)
        {
            transform.position = startingPos;
        }
    }
}
