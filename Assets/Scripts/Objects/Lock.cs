using UnityEngine;

public class Lock : MonoBehaviour, InteractF
{
    GameObject player;
    [SerializeField] Transform entryPointInNextScene;
    [SerializeField] private ScreenFader screenFader;
    bool canPick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canPick = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractWithObjectF()
    {
        if (canPick)
        { 
            StartCoroutine(screenFader.FadeOutIn(() =>
        {
            player.transform.position = entryPointInNextScene.position;
        }));
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallFormHitbox")
        {
            canPick = true;
            player = collision.transform.root.gameObject;

        }
    }
}
