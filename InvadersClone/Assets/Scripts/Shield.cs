using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite[] state;
    private int health;
    private SpriteRenderer sr;

    private void Start()
    {
        health = 4;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            health--;
            if(health <=0)
            {
                Destroy(gameObject);
            }
            else
            {
                sr.sprite = state[health - 1];
            }
        }
    }
}
