using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float enemyBulletSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * enemyBulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
