using UnityEngine;

public class RockSwitch : MonoBehaviour
{
    public GameObject fogOfWarSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "MovableSmall")
        {
            fogOfWarSprite.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MovableSmall")
        {
            fogOfWarSprite.SetActive(true);
        }
    }
}
