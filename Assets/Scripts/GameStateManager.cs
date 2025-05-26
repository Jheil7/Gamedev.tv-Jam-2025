using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public bool leftWellForFirstTime;
    public bool lockPickCompleted;
    public bool keyAcquired;
    public bool shovelAcquired;

    void Start()
    {
        leftWellForFirstTime = false;
        lockPickCompleted = false;
        keyAcquired = false;
        shovelAcquired = false;
    }
}
