using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string nextScene;
    public Transform entryPointInNextScene;
    public GameObject player;

    // public void Transition()
    // {
    //     StartCoroutine(LoadSceneAndMovePlayer());
    // }

    // public void LoadSceneAndMovePlayer()
    // {
    //     player.transform.position = entryPointInNextScene.position;
    // }
}
