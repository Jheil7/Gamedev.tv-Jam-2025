using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    public Transform respawn;
    public Transform rockRespawn;
    [SerializeField] private ScreenFader screenFader;
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
            StartCoroutine(screenFader.FadeOutIn(() =>
            {
                collision.transform.root.position = respawn.position;
            }));
        }
        if (collision.tag == "MovableSmall")
        {
            collision.transform.position = rockRespawn.position;
         }
    }
}
