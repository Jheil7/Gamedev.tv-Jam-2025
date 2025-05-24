using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public bool leftWellForFirstTime;
    public bool lockPickCompleted;
    public bool keyAcquired;

    void Start()
    {
        leftWellForFirstTime = false;
        lockPickCompleted = false;
        keyAcquired = false;
    }
}
