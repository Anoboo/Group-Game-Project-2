using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessed_Rains_Down_In_Africa_Script : MonoBehaviour
{
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
        if(other.gameObject.tag == "Enemy")
        {
            gameControllerRef.GetComponent<Score>().IncreaseScore();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
