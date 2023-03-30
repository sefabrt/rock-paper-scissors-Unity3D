using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDeathEffect : MonoBehaviour
{
    public ParticleSystem death;
    void Start()
    {
        
    }
    public void deatheffect()
    {
        Instantiate(death, transform.position, Quaternion.identity);
        
    }
}
