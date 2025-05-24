using UnityEngine;

public class PadlockParent : MonoBehaviour
{
    [SerializeField] GameStateManager gameStateManager;
    [SerializeField] GameObject lockedPadlock;
    [SerializeField] GameObject unlockedPadlock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateManager.lockPickCompleted == true)
        {
            DoorOpen();
        }
        else
        {
            unlockedPadlock.SetActive(false);
            lockedPadlock.SetActive(true);
        }
    }

    void DoorOpen()
    {
        unlockedPadlock.SetActive(true);
        lockedPadlock.SetActive(false);
    }
}
