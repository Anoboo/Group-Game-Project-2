using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Turret_Blueprint standardTurret;
    public Turret_Blueprint sniperTower;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchaseMovingTurret()
    {
        Debug.Log("Moving Turret Purchased");
        buildManager.SetTurretBuild(standardTurret);
    }

    public void PurchaseSniperTower()
    {
        Debug.Log("Sniper Tower Purchased");
        buildManager.SetTurretBuild(sniperTower);
    }
}
