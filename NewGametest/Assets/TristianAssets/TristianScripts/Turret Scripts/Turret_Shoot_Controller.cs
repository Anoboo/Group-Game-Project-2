using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Shoot_Controller : MonoBehaviour
{
    private GameObject enemyHealthRef;
    private GameObject refEnmeyHealth;

    // Start is called before the first frame update
    void Start()
    {
       enemyHealthRef = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
