using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBgChars : MonoBehaviour
{
    [SerializeField] private Vector2 SpawnPointMax;
    [SerializeField] private GameObject SpawnEdilecek;
    [SerializeField] private GameObject deatheffect;
    private Vector2 nextPos;
    [SerializeField] private float MoveSpeed;

    [SerializeField] private Vector2 SpawnPoint;
    private void Start()
    {
        ChangeNextPos();
    }
    private void Update()
    {
        if (transform.position.x == nextPos.x && transform.position.y == nextPos.y)
        {
            ChangeNextPos();
        }
        else { MoveToNextPos(); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        Instantiate(SpawnEdilecek, SpawnPoint, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
    private void ChangeNextPos()
    {
        float x = Random.Range(SpawnPointMax.x * -1, SpawnPointMax.x);
        float y = Random.Range(SpawnPointMax.y * -1, SpawnPointMax.y);
        nextPos = new Vector2(x, y);
    }
    private void MoveToNextPos()
    {
        transform.position = Vector2.MoveTowards(transform.position, nextPos, MoveSpeed * Time.deltaTime);
    }
}
