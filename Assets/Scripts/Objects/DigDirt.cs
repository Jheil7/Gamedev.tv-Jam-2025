using UnityEngine;

public class DigDirt : MonoBehaviour, InteractF
{
    public GameStateManager gameStateManager;
    bool canDig;
    public GameObject dirtPile;
    public GameObject fogOfWar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canDig = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractWithObjectF()
    {
        if (gameStateManager.shovelAcquired && canDig)
        {
            dirtPile.SetActive(false);
            fogOfWar.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BigFormHitbox")
        {
            canDig = true;
        }
        if (collision.tag == "SmallFormHitbox")
        {
            canDig = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "BigFormHitbox"|| collision.tag == "SmallFormHitbox"){
            canDig = false;
        }
    }
}
