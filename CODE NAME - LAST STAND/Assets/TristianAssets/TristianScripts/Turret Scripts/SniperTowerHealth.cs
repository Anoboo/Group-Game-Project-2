using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperTowerHealth : MonoBehaviour
{
    [SerializeField] private int sniperTowerHealth = 2;
    public Image healthBar;
    [SerializeField] private float Health = 2;
    public GameObject mainHealthBar;

    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        Health = sniperTowerHealth;
        buildManager = BuildManager.instance;
        InvokeRepeating("ZombieIsAttackingTurret", 0f, 3f);
        mainHealthBar.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(sniperTowerHealth < 5)
        {
            mainHealthBar.SetActive(true);
        }

        healthBar.fillAmount = sniperTowerHealth / Health;

        if(sniperTowerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ZombieIsAttackingTurret()
    {
        if (Zombies_Attacking_Turrets.target != null && Zombies_Attacking_Turrets.hasTarget == true)
        {
            sniperTowerHealth--;
        }
        Debug.Log("Health has been taken from the turret! Your turret's health is now: " + sniperTowerHealth);
    }
}
