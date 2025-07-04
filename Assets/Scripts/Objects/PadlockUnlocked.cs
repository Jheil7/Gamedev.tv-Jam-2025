using UnityEngine;

public class PadlockUnlocked : MonoBehaviour, InteractF
{
    GameObject player;
    [SerializeField] Transform entryPointInNextScene;
    bool abletoMoveOn;
    [SerializeField] private ScreenFader screenFader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        abletoMoveOn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractWithObjectF()
    {
        if (abletoMoveOn)
        { 
        StartCoroutine(screenFader.FadeOutIn(() =>
        {
            player.transform.position = entryPointInNextScene.position;
        }));
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BigFormHitbox")
        {
            abletoMoveOn = true;
            player = collision.transform.root.gameObject;
        }
        else { abletoMoveOn = false; }
    }
}
