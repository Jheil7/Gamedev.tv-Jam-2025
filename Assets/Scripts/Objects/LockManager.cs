using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public static LockManager Instance;
    [SerializeField] GameStateManager gameStateManager;

    public List<int> correctOrder = new List<int> { 2, 1, 3, 5, 4 };

    private int currentIndex = 0;
    private List<Tumbler> poppedTumblers = new();

    private void Awake()
    {
        Instance = this;
    }

    public void TumblerHit(int tumblerID, Tumbler tumbler)
    {
        Debug.Log($"Hit tumbler: {tumblerID}");

        if (tumblerID == correctOrder[currentIndex])
        {
            tumbler.PopUp();
            poppedTumblers.Add(tumbler);
            currentIndex++;

            if (currentIndex >= correctOrder.Count)
            {
                Unlock();
            }
        }
        else
        {
            ResetTumblers();
        }
    }

    private void Unlock()
    {
        gameStateManager.lockPickCompleted = true;
        Debug.Log("Lock opened!");
        // Door open animation, cutscene, etc.
    }

    private void ResetTumblers()
    {
        Debug.Log("Incorrect tumbler. Resetting.");

        foreach (var t in poppedTumblers)
        {
            t.ResetPosition();
        }

        poppedTumblers.Clear();
        currentIndex = 0;
    }
}