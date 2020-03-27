using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTurretHealth : MonoBehaviour
{
    public static int movingTurretHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movingTurretHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
