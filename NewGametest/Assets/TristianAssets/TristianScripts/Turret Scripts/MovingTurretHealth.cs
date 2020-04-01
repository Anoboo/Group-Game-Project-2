using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingTurretHealth : MonoBehaviour
{
    public static int movingTurretHealth = 5;
    public Image HealthBar;
    public static float Health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Health = movingTurretHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = movingTurretHealth / Health;

        if(movingTurretHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
