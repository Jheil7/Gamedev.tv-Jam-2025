using UnityEngine;

public class ShedUnlocked : MonoBehaviour
{
    public GameStateManager gameStateManager;
    public GameObject lockedShed;
    public GameObject closedUnlockedShed;
    public GameObject unlockedShed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lockedShed.SetActive(true);
        closedUnlockedShed.SetActive(false);
        unlockedShed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // public void InteractWithObjectF()
    // {
    //     ableToOpen=unlockedShedCollider.CanOpen;
    //     Debug.Log("opened the shed");
    //     if (gameStateManager.keyAcquired == true && ableToOpen)
    //     {
    //         closedUnlockedShed.SetActive(false);
    //         unlockedShed.SetActive(true);
    //         Debug.Log("opened the shed");
    //     }
    // }
}
