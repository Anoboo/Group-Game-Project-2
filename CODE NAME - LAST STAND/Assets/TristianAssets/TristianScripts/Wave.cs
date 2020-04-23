using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wave : MonoBehaviour
{
    [SerializeField] private float enemiesDestroyed;
    [SerializeField] private int waveCount;
    [SerializeField] private TextMeshProUGUI waveText;
    private GameObject gameControllerRef;
    [SerializeField] private float shamblersDestroyCount;

    // Start is called before the first frame update
    void Start()
    {
        waveCount = 1;
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        while(waveCount == 1)
        {
            gameControllerRef.GetComponent<EnemySpawn>().SpawnEnemy();
            if(enemiesDestroyed >= 6)
            {
                waveCount = waveCount + 1;
            }
        }

        while(waveCount == 2)
        {
            gameControllerRef.GetComponent<EnemySpawn>().SpawnEnemy();
            if(shamblersDestroyCount >= 5)
            {
                gameControllerRef.GetComponent<EnemySpawn>().BeefCakeSpawn();
                shamblersDestroyCount = shamblersDestroyCount - 5;
            }

            if(enemiesDestroyed >= 15)
            {
                waveCount = waveCount + 1;
            }
        }

        while(waveCount == 3)
        {
            gameControllerRef.GetComponent<EnemySpawn>().SpawnEnemy();
            gameControllerRef.GetComponent<EnemySpawn>().BeefCakeSpawn();
        }
    }

    public void WaveCount()
    {
        waveCount = waveCount + 1;
        UpdateUI();
    }

    public void EnemiesDestroyed()
    {
        enemiesDestroyed = enemiesDestroyed + 1;
        UpdateUI();
    }

    public void ShamblersDestroyedCount()
    {
        shamblersDestroyCount = shamblersDestroyCount + 1;
    }

    void UpdateUI()
    {
        waveText.text = "Wave: " + waveCount;
    }
}
