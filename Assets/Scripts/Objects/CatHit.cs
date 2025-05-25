using UnityEngine;

public class CatHit : MonoBehaviour
{
    public Transform outside;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallFormHitbox")
        {
            collision.transform.root.position = outside.position;
        }
    }
}
