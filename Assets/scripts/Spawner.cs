using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	float timer;
	public GameObject[] SpawnEdilecekler;
    private DifficultyManager dm;
    void Update()
    {
        
        if (!GetComponent<gameoverseysi>().gameover)
        {
            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Instantiate(SpawnEdilecekler[Random.Range(0, 3)], new Vector2(10, 0), Quaternion.identity);
                timer = dm.spawnSpeed;
            }
        }
    }
    private void Start()
    {
        timer = 0.5f;
        dm=GameObject.Find("Manager").GetComponent<DifficultyManager>();
    }
}
