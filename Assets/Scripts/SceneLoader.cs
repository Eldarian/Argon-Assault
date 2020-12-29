using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadGame", 3f);
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
