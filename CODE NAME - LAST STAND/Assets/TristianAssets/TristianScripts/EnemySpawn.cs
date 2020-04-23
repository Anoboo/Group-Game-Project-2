using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // For enemy 1
    public GameObject Enemy_1;
    public GameObject BeefCakeEnemy;
    public Transform Spawn_1;
    public Transform BeefCakeSpawnLocation;
    private Vector3 EnemyLocation;
    private GameObject enemyRef;
    private float SpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        SpawnDelay = Random.Range(2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Vector3 EnemyLocation = Spawn_1.position;
        enemyRef = Instantiate(Enemy_1, EnemyLocation, transform.rotation * Quaternion.Euler(0f, -53.741f, 0f));

        Invoke("SpawnEnemy", SpawnDelay);
    }

    public void BeefCakeSpawn()
    {
        Vector3 EnemyLocation = BeefCakeSpawnLocation.position;
        enemyRef = Instantiate(BeefCakeEnemy, EnemyLocation, transform.rotation * Quaternion.identity);

        Invoke("BeefCakeSpawn", SpawnDelay);
    }
}
