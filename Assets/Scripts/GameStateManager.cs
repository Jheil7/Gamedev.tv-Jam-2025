using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public bool lockPickCompleted;
    public bool keyAcquired;

    void Start()
    {
        lockPickCompleted = false;
        keyAcquired = false;
    }
}
