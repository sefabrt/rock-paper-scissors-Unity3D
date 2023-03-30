using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] effects;
    public string playertagNow;
    public GameObject playerNow;
    public string[] playerNames;
    public Vector2 PlayerSpawnPoint;
    public GameObject[] players;
    Dictionary<string, int> tagtoindex = new Dictionary<string, int>();
    private void Start()
    {
        tagtoindex.Add("das", 0);
        tagtoindex.Add("kagiz", 1);
        tagtoindex.Add("qayci", 2);
    }
    public void YeniPlayerOlustur(string playertag)
    {
        if (!GetComponent<gameoverseysi>().gameover)
        {
            Instantiate(effects[tagtoindex[playertag]], PlayerSpawnPoint, Quaternion.identity);
            Instantiate(players[tagtoindex[playertag]], PlayerSpawnPoint, Quaternion.identity);
        }
    }

    public void DestroyCurrentPlayerObj()
    {
        if (!GetComponent<gameoverseysi>().gameover)
        {
            foreach (string name in playerNames)
            {
                Destroy(GameObject.Find(name));

            }
        }
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
