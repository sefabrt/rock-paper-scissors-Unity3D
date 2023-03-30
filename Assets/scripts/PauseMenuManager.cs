using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject PausedScreen;
    private gameoverseysi gos;
    private void Start()
    {
        gos = GetComponent<gameoverseysi>();
    }
    public void PauseGame()
    {
        gos.gameover = true;
        PausedScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        gos.gameover = false;
        PausedScreen.SetActive(false);
    }

}
