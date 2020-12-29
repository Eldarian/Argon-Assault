using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float restartDelay = 1.0f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject explosionFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        explosionFX.SetActive(true);
        Invoke("ReloadScene", restartDelay);
        //explosionFX.GetComponent<Exploder>().Explode();
        //Destroy(gameObject);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1    );
    }
}
