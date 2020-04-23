using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Turret_Blueprint standardTurret;
    public Turret_Blueprint sniperTower;
    public Turret_Blueprint laserTower;
    public Turret_Blueprint rocketTurret;

    //public static GameObject movingTurret;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        //movingTurret = standardTurret.prefab;
    }

    public void PurchaseMovingTurret()
    {
        Debug.Log("Moving Turret Purchased");
        buildManager.SetMovingTurretBuild(standardTurret);

        /*if(buildManager.movingTurretLimit == 1)
        {
            standardTurret = null;
        }*/
    }

    public void PurchaseSniperTower()
    {
        Debug.Log("Sniper Tower Purchased");
        buildManager.SetTurretBuild(sniperTower);
    }

    public void PurchaseLaserTower()
    {
        Debug.Log("Laser Tower Purchased");
        buildManager.SetTurretBuild(laserTower);
    }

    public void PurchaseRocketTurret()
    {
        Debug.Log("Rocter Turret Purchased");
        buildManager.SetTurretBuild(rocketTurret);
    }
}
