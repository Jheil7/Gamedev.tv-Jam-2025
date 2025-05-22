using UnityEngine;

public class Lock : MonoBehaviour, InteractF
{
    GameObject player;
    [SerializeField] Transform entryPointInNextScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractWithObjectF()
    {
        player.transform.position = entryPointInNextScene.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallFormHitbox")
        {
            player = collision.transform.root.gameObject;
        }
    }
}
