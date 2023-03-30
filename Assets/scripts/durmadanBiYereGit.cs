using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class durmadanBiYereGit : MonoBehaviour
{
	[SerializeField]
	Vector2 istiqamet;
    [SerializeField]
    private DifficultyManager dm;
    private gameoverseysi gameoverseysi;

    void Start()
    {
        dm = GameObject.Find("Manager").GetComponent<DifficultyManager>();
        gameoverseysi = GameObject.Find("Manager").GetComponent<gameoverseysi>();
        GetComponent<Rigidbody2D>().velocity = istiqamet * dm.speed;
    }
    private void Update()
    {
        if (gameoverseysi.gameover && GetComponent<Rigidbody2D>().velocity != istiqamet * 0)
        {
            GetComponent<Rigidbody2D>().velocity = istiqamet * 0;
        }
        else if (!gameoverseysi.gameover && GetComponent<Rigidbody2D>().velocity == istiqamet * 0)
        {
            GetComponent<Rigidbody2D>().velocity = istiqamet * dm.speed;
        }
        
    }
    
}
