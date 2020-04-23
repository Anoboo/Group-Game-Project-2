using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeefCake_Health : MonoBehaviour
{
    [SerializeField] private int beefCakehealth = 9;
    private GameObject gameControllerRef;
    [SerializeField] private float Health = 9;
    public Image HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerRef = GameObject.FindGameObjectWithTag("GameController");
        Health = beefCakehealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            beefCakehealth--;
            HealthBar.fillAmount = Health / beefCakehealth;

            Debug.Log("Health has been taken from Beef Cake: " + beefCakehealth);

            if(beefCakehealth <= 0)
            {
                gameControllerRef.GetComponent<Score>().BeefCakeIncreaseScore();
                Money.money = Money.money + 100;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "Moving Turret Bullet")
        {
            Health -= 3;
            HealthBar.fillAmount = Health / beefCakehealth;

            print("Health has been taken from the enemy." + beefCakehealth);

            if (Health <= 0)
            {
                gameControllerRef.GetComponent<Score>().IncreaseScore();
                Money.money = Money.money + 50;
                Destroy(gameObject);
            }
        }
    }
}
