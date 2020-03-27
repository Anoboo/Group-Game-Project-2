using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefCake_Health : MonoBehaviour
{
    [SerializeField] private int beefCakehealth = 9;
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
            beefCakehealth--;

            Debug.Log("Health has been taken from Beef Cake: " + beefCakehealth);

            if(beefCakehealth <= 0)
            {
                gameControllerRef.GetComponent<Score>().BeefCakeIncreaseScore();
                Money.money = Money.money + 100;
                Destroy(gameObject);
            }
        }
    }
}
