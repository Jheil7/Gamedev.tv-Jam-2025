using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] float cameraXoffset;
    [SerializeField] float cameraYoffset;
    Vector3 cameraOffsetVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraOffsetVector = new Vector3(cameraYoffset, cameraYoffset, -1);
    }

    // Update is called once per frame
    void Update()
    {
        cameraOffsetVector = new Vector3(cameraXoffset, cameraYoffset, -1);
        transform.position = playerTransform.position+cameraOffsetVector;
    }
}
