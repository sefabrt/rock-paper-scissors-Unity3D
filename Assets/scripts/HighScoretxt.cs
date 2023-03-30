using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoretxt : MonoBehaviour
{
    void Update()
    {
        GetComponent<TMP_Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
