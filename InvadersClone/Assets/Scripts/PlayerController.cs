using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    //public float PlayerSpeed;

    private const float minX = -3.05f;
    private const float maxX = 3.05f;
    private bool isShooting;
    //private float cooldawn = 0.5f;
    [SerializeField] private ObjectsPooling objectPool = null;

    public ShipStats shipStats;
    private Vector2 offScreenPos = new Vector2(0, -20);
    private Vector2 startPos = new Vector2(0, -5f);


    private void Start()
    {
        shipStats.currentHealth = shipStats.MaxHealth;
        shipStats.currentLifes = shipStats.maxLifes;
        transform.position = startPos;

        UIManager.UpdateHealthBar(shipStats.currentHealth);
        UIManager.UpdateLives(shipStats.currentLifes);
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.ShipSpeed);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.ShipSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
#endif
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        // Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        GameObject obj = objectPool.GetPooledObjects();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player Hit...");
            collision.gameObject.SetActive(false);
            TakeDamage();
        }
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos; 
        yield return new WaitForSeconds(2);
        shipStats.currentHealth = shipStats.MaxHealth;
        transform.position = startPos;
        UIManager.UpdateHealthBar(shipStats.currentHealth);
    }

    public void TakeDamage()
    {
        shipStats.currentHealth--;
        UIManager.UpdateHealthBar(shipStats.currentHealth);
        if(shipStats.currentHealth <= 0)
        {
            shipStats.currentLifes--;
            UIManager.UpdateLives(shipStats.currentLifes);
            if (shipStats.currentLifes <= 0)
            {
                Debug.Log("Game Over...");
            }
            else
            {
               // Debug.Log("Respawn");
                StartCoroutine(Respawn());
            }
        }
        
    }
}
