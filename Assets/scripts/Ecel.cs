using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ecel : MonoBehaviour
{
    [SerializeField]
    float deathNote;
    void Start()
    {
        Destroy(gameObject, deathNote);
    }
    
}
