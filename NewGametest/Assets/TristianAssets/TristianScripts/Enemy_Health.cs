using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 3;
    private GameObject gameControllerRef;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            enemyHealth--;

            print("Health has been taken from the enemy." + enemyHealth);

            if(enemyHealth <= 0)
            {
                gameControllerRef.GetComponent<Score>().IncreaseScore();
                gameControllerRef.GetComponent<Money>().MoneyCount();
                Destroy(gameObject);
            }
        }
    }
}
