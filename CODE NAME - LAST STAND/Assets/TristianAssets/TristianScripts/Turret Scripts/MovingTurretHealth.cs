using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingTurretHealth : MonoBehaviour
{
    [SerializeField] private int movingTurretHealth = 10;
    public Image HealthBar;
    [SerializeField] private float Health = 10;
    public GameObject mainHealthBar;

    BuildManager buildmanager;

    // Start is called before the first frame update
    void Start()
    {
        Health = movingTurretHealth;
        buildmanager = BuildManager.instance;
        InvokeRepeating("ZombieIsAttackingTurret", 0f, 3f);
        mainHealthBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(movingTurretHealth < 20)
        {
            mainHealthBar.SetActive(true);
        }

        HealthBar.fillAmount = movingTurretHealth / Health;

        if(movingTurretHealth <= 0)
        {
            Destroy(gameObject);
            buildmanager.movingTurretLimit = 0;
        }
    }

    private void ZombieIsAttackingTurret()
    {
        if(Zombies_Attacking_Turrets.target != null && Zombies_Attacking_Turrets.hasTarget == true)
        {
            movingTurretHealth--;
        }
        Debug.Log("Health has been taken from the turret! Your turret's health is now: " + movingTurretHealth);
    }
}
