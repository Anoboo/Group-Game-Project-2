using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int towerHealth = 1;
    public GameObject restartButton;
    bool timeStop = false;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false); 
        if(timeStop == false)
        {
            Time.timeScale = 1;
            timeStop = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            towerHealth--;

            if(towerHealth <= 0)
            {
                Destroy(gameObject);
                restartButton.SetActive(true);
                timeStop = true;
                if(timeStop == true)
                {
                    Time.timeScale = 0;
                    timeStop = true;
                }
            }
        }
    }
}
