using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreSys : MonoBehaviour
{
    public int score;

    public TMP_Text scoreTXT;
    void Start()
    {
        score = 0;
    }
    void Update()
    {
        scoreTXT.text = "Score: " + score.ToString();
        if (GetComponent<gameoverseysi>().gameover)
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
}
