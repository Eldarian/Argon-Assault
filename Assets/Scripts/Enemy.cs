using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] int scorePerHit;
    [SerializeField] int hits = 5;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        hits--;
        Debug.Log(gameObject.name + "hit!");
        if (hits <= 0)
        {
            KillEnemy();
            Debug.Log(gameObject.name + "dead!");

        }
    }

    private void KillEnemy()
    {
        scoreBoard.ScoreHit(scorePerHit);
        Instantiate(enemyDeathFX, transform.position, Quaternion.identity, GameObject.Find("Spawned Objects").transform);
        Destroy(gameObject);
    }

}
