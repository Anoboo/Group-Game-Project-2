using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprinter_Zombie_Health : MonoBehaviour
{
    public Image HealthBar;
    [SerializeField] private int enemyHealth = 5;
    [SerializeField] private float Health = 5;
    private GameObject gameControllerRef;
    //public GameObject mainHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
        Health = enemyHealth;
        //mainHealthBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth < 5)
        {
            //mainHealthBar.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Health--;
            HealthBar.fillAmount = Health / enemyHealth;

            print("Health has been taken from the enemy." + enemyHealth);

            if (Health <= 0)
            {
                gameControllerRef.GetComponent<Score>().IncreaseScore();
                Money.money = Money.money + 50;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "Moving Turret Bullet")
        {
            Health -= 3;
            HealthBar.fillAmount = Health / enemyHealth;

            print("Health has been taken from the enemy." + enemyHealth);

            if (Health <= 0)
            {
                gameControllerRef.GetComponent<Score>().IncreaseScore();
                Money.money = Money.money + 50;
                Destroy(gameObject);
            }
        }
    }
}
