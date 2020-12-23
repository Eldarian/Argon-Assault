using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
