using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    ParticleSystem explosionVFX;
    AudioSource explosionSFX;
    // Start is called before the first frame update
    void Start()
    {
        explosionSFX = gameObject.GetComponent<AudioSource>();
        explosionVFX = gameObject.GetComponent<ParticleSystem>();
    }

    public void Explode()
    {
        explosionVFX.Play();
        explosionSFX.Play();
    }
}
