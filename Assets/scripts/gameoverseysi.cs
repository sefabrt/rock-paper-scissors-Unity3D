using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverseysi : MonoBehaviour
{
    public bool gameover;
    public GameObject GameOverCanvas,PauseButton;
    private void Awake()
    {
        gameover=false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);
        GameOver();
    }
    public void GameOver()
    {
        gameover = true;
        PauseButton.SetActive(false);
        GameOverCanvas.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
