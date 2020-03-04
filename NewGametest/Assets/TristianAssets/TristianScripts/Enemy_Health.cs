using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public Image HealthBar;
    [SerializeField] private int enemyHealth = 3;
    [SerializeField] private float Health = 3;
    private GameObject gameControllerRef;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
        Health = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Health--; 
            HealthBar.fillAmount = Health / enemyHealth;

            print("Health has been taken from the enemy." + enemyHealth);

            if(Health <= 0)
            {
                gameControllerRef.GetComponent<Score>().IncreaseScore();
                Money.money = Money.money + 50;
                Destroy(gameObject);
            }
        }
    }
}
