using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyEnemy : MonoBehaviour
{
    Dictionary<string, string> OyunMantigi=new Dictionary<string, string>();
    public gameoverseysi gameover;
    private AudioSource deathSound;

    public scoreSys scoresys;
    void Start()
    {
        OyunMantigi.Add("das", "qayci");
        OyunMantigi.Add("kagiz", "das");
        OyunMantigi.Add("qayci", "kagiz");
        gameover = GameObject.Find("Manager").GetComponent<gameoverseysi>();
        scoresys = GameObject.Find("Manager").GetComponent<scoreSys>();
        deathSound = GameObject.Find("Manager").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OyunMantigi[gameObject.tag] == collision.gameObject.tag)
        {
            collision.GetComponent<CharDeathEffect>().deatheffect();
            Destroy(collision.gameObject);
            deathSound.Play();
            scoresys.score++;
        }else if (gameObject.tag == collision.gameObject.tag)
        {
            collision.GetComponent<CharDeathEffect>().deatheffect();
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            DestroyMe();
            
        }
        else {
            collision.GetComponent<CharDeathEffect>().deatheffect();
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,0f,0f);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            DestroyMe();
            
        }
        
    }
    public void DestroyMe()
    {
        GetComponent<CharDeathEffect>().deatheffect();
        Destroy(gameObject);
        gameover.GameOver();
    }
}
