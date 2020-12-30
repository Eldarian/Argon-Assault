using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float SelfDestructionTime = 5f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

}
