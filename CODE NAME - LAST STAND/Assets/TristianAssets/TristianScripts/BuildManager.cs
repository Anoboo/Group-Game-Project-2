using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private Turret_Blueprint turretToBuild;
    public int movingTurretLimit = 0;

    private Base_Turret_Placements selectedTurret;

    public Turret_UI_Script turretUI;

    public GameObject movingTurretButton;

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

    private void Start()
    {
        movingTurretLimit = 0;
        movingTurretButton.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(movingTurretLimit == 0)
        {
            movingTurretButton.SetActive(true);
        }

        if(movingTurretLimit == 1)
        {
            movingTurretButton.SetActive(false);
        }
    }

    // This function is for when a turret has been selected and has been assigned a place to be built.
    public void SelectTurret(Base_Turret_Placements turretSelected)
    {
        if(selectedTurret == turretSelected)
        {
            DeselectTurret();
            return;
        }
        selectedTurret = turretSelected;
        turretToBuild = null;

        turretUI.SetTarget(turretSelected);
    }

    // This is to deselect the turret you chose to build.
    public void DeselectTurret()
    {
        selectedTurret = null;
        turretUI.Hide();
    }

    // Sets what turret is going to be built.
    public void SetTurretBuild(Turret_Blueprint turret)
    {
        turretToBuild = turret;
        selectedTurret = null;

        DeselectTurret();
    }

    // This limits and allows to spawn the moving turret which is now a special turret.
    public void SetMovingTurretBuild(Turret_Blueprint movingTurret)
    {
        if(movingTurretLimit == 0 && Money.money >= 2500)
        {
            turretToBuild = movingTurret;
            selectedTurret = null;

            DeselectTurret();

            movingTurretLimit = 1;
        }
        else
        {
            //movingTurretButton.SetActive(false);
            return;
        }
        
    }

    public Turret_Blueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    // This allows for the moving turret to be built on the nodes.
    public void BuildMovingTurretOn(Base_Turret_Placements base_Moving_Turret_Placements)
    {
        if (Money.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        Money.money -= turretToBuild.cost;

        GameObject movingturret = Instantiate(turretToBuild.prefab, base_Moving_Turret_Placements.GetBuildPosition(), Quaternion.identity);
        base_Moving_Turret_Placements.turret = movingturret;
        
        Debug.Log("Turret built! Money left: " + Money.money);
    }

    // This allows for all other types of turrets to be spawned in when the player has enough money to build the turrets.
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
