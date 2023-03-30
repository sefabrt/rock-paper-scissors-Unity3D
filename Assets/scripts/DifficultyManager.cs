using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public float minSpeed, maxSpeed, minSpSpeed, maxSpSpeed, maxDifficultyTime, speed, spawnSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
        spawnSpeed= Mathf.Lerp(minSpSpeed, maxSpSpeed, 1-GetDifficultyPercent());
    }
    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / maxDifficultyTime);
    }
}
