using UnityEngine;

public class Lock : MonoBehaviour, InteractF
{
    GameObject player;
    [SerializeField] Transform entryPointInNextScene;
    [SerializeField] private ScreenFader screenFader;
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
        StartCoroutine(screenFader.FadeOutIn(() =>
        {
            player.transform.position = entryPointInNextScene.position;
        }));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallFormHitbox")
        {
            player = collision.transform.root.gameObject;
        }
    }
}
