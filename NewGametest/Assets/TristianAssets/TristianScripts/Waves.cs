using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting };
    public TextMeshProUGUI waveNameText;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public Transform beefCake;
        public int count;
        public float spawnDelay;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    [SerializeField] private float waveCountDown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.Counting;

    // Start is called before the first frame update
    void Start()
    {
        waveNameText.enabled = false;
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }
        waveCountDown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == SpawnState.Waiting)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }
        if(waveCountDown <= 0)
        {
            StartCoroutine(WaveNameText());
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.Counting;
        waveCountDown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Wave Completed! Looping...");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.Spawning;

        for(int i = 0; i < _wave.count; i++)
        {
            //yield return new WaitForSeconds(specificEnemySpawnDelay);
            if(nextWave == 0 || nextWave == 1 && Random.value <= 1)
            {
                SpawnEnemy(_wave.enemy);
            }

            if (nextWave == 2 && Random.value <= 0.7)
            {
                SpawnEnemy(_wave.enemy);
            }
            if (nextWave == 2 && Random.value > 0.7)
            {
                SpawnEnemyBeefCake(_wave.beefCake);
            }
            yield return new WaitForSeconds(1f / _wave.spawnDelay);
        }

        state = SpawnState.Waiting;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy" + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, transform.rotation);
    }

    void SpawnEnemyBeefCake(Transform _BeefCakeEnemy)
    {
        Debug.Log("Spawning BEEF CAKE" + _BeefCakeEnemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_BeefCakeEnemy, _sp.position, transform.rotation);
    }

    IEnumerator WaveNameText()
    {
        if(nextWave == 0)
        {
            waveNameText.enabled = true;
            waveNameText.text = "The First Wave Is Rapidly Approaching! " + "\n" + "GET READY!";
            yield return new WaitForSeconds(3);
            waveNameText.enabled = false;

            yield break;
        }

        if (nextWave > 0)
        {
            waveNameText.enabled = true;
            waveNameText.text = "The Next Wave Is Rapidly Approaching! " + "\n" + "GET READY!";
            yield return new WaitForSeconds(3);
            waveNameText.enabled = false;

            yield break;
        }
    }
}
