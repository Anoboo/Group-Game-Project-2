using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // For enemy 1
    public GameObject Enemy_1;
    public Transform Spawn_1;
    private Vector3 EnemyLocation;
    private GameObject enemyRef;
    public float SpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 EnemyLocation = Spawn_1.position;
        enemyRef = Instantiate(Enemy_1, EnemyLocation, transform.rotation * Quaternion.identity);

        Invoke("SpawnEnemy", SpawnDelay);
    }
}
