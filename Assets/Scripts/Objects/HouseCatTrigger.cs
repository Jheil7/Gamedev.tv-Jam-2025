using UnityEngine;

public class HouseCatTrigger : MonoBehaviour
{
    public GameObject houseCat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Seed"))
        {
            houseCat.SetActive(true);
        }
    }    
}
