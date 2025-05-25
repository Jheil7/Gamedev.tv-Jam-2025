using UnityEngine;

public class UnlockedShedCollider : MonoBehaviour,InteractF
{
    public GameStateManager gameStateManager;
    public GameObject openShed;
    public bool canOpen;

    public bool CanOpen
    {
        get { return canOpen; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void InteractWithObjectF()
    {
        if (gameStateManager.keyAcquired == true && canOpen)
        {
            openShed.SetActive(true);
            gameObject.SetActive(false);
            
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BigFormHitbox")
        {
            canOpen = true;
        }

        else if (collision.tag == "SmallFormHitbox")
        {
            canOpen = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BigFormHitbox" || collision.tag == "SmallFormHitbox")
        {
            canOpen = false;
        }
    }
}
