using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefCakeHealthTitleMenu : MonoBehaviour
{
    [SerializeField] private int beefCakehealth = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            beefCakehealth--;

            Debug.Log("Health has been taken from Beef Cake: " + beefCakehealth);

            if (beefCakehealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
