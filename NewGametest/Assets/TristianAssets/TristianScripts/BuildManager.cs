using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private Turret_Blueprint turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject sniperTowerPrefab;
    private Base_Turret_Placements selectedTurret;

    public Turret_UI_Script turretUI;
    public bool CanBuild { get { return turretToBuild != null; } }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTurret(Base_Turret_Placements turretSelected)
    {
        if(selectedTurret == turretSelected)
        {
            DeselectTurret();
            return;
        }
        turretSelected = selectedTurret;
        turretToBuild = null;

        turretUI.SetTarget(turretSelected);
    }

    public void DeselectTurret()
    {
        selectedTurret = null;
        turretUI.Hide();
    }

    public void SetTurretBuild(Turret_Blueprint turret)
    {
        turretToBuild = turret;
        selectedTurret = null;

        DeselectTurret();
    }

    public void BuildTurretOn(Base_Turret_Placements base_Turret_Placements)
    {
        if(Money.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        Money.money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, base_Turret_Placements.GetBuildPosition(), Quaternion.identity);
        base_Turret_Placements.turret = turret;

        Debug.Log("Turret built! Money left: " + Money.money);
    }
}
