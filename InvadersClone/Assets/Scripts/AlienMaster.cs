using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    [SerializeField] private ObjectsPooling objectPool = null;

    public GameObject EnemyBulletPrefabs;

    private Vector3 hMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.15f, 0);

    private const float MAX_LEFT = -2.80f;
    private const float MAX_RIGHT = 2.80f;

    public static List<GameObject> AllEnemies = new List<GameObject>();

    private bool isMovingRight;

    private float moveTimer = 0.01f;
    private float moveTime = 0.05f;

    private float shootTimer = 3f;
    private const float shootTime = 3f;

    private const float max_moveSpeed = 0.02f;

    public GameObject MotherShipPrefab;
    private Vector3 motherShipSpawnPos = new Vector3(3.90f, 3.0f, 0);
    private float motherShipTimer = 1f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60f;

    void Start()
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Alien"))
        {
            AllEnemies.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer < 0)
        {
            MoveEnemies();
        }
        if (shootTimer < 0)
        {
            Shoot();
        }
        if(motherShipTimer <= 0)
        {
            SpawnMotherShip();
        }
        moveTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;
        motherShipTimer -= Time.deltaTime;
    }

    private void MoveEnemies()
    {
        int hitMax = 0;

        if (AllEnemies.Count > 0)
        {
            for (int i = 0; i < AllEnemies.Count; i++)
            {
                if (isMovingRight)
                {
                    AllEnemies[i].transform.position += hMoveDistance;
                }
                else
                {
                    AllEnemies[i].transform.position -= hMoveDistance;
                }
                if (AllEnemies[i].transform.position.x > MAX_RIGHT || AllEnemies[i].transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }
            }
            if (hitMax > 0)
            {
                for (int i = 0; i < AllEnemies.Count; i++)
                {
                    AllEnemies[i].transform.position -= vMoveDistance;
                }
                isMovingRight = !isMovingRight;
            }
            moveTimer = GetMoveSpeed();
        }
    }

    private void SpawnMotherShip()
    {
        Instantiate(MotherShipPrefab, motherShipSpawnPos, Quaternion.identity);
        motherShipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }

    private void Shoot()
    {
        Vector2 pos = AllEnemies[Random.Range(0, AllEnemies.Count)].transform.position;
        //Instantiate(EnemyBulletPrefabs, pos, Quaternion.identity);
        GameObject obj = objectPool.GetPooledObjects();
        obj.transform.position = pos;

        shootTimer = shootTime;
    }

    private float GetMoveSpeed()
    {
        float f = AllEnemies.Count * moveTime;

        if (f < max_moveSpeed)
        {
            return max_moveSpeed;
        }
        else
        {
            return f;
        }
    }
}
