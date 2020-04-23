using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Base_Turret_Placements : MonoBehaviour
{
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public Turret_Blueprint turret_Blueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 positionOffset;

    public Color hoverColor;
    private Color startColor;
    private Renderer rend;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }



    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectTurret(this);
            return;
        }

        /*if(Shop.movingTurret != null)
        {
            buildManager.SelectTurret(this);
            return;
        }*/

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
        //buildManager.BuildTurretOn(this);
    }

    void BuildTurret(Turret_Blueprint blueprint)
    {


        if (Money.money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        Money.money -= blueprint.cost;

        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turret_Blueprint = blueprint;

        isUpgraded = true;

        Debug.Log("Turret built! Money left: " + Money.money);

    }

    public void UpgradeTurret()
    {

        if (Money.money < turret_Blueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        Money.money -= turret_Blueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = Instantiate(turret_Blueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        print("Turret Upgraded! Money left: " + Money.money);

    }
    public void SellTurret()
    {
        Money.money += turret_Blueprint.GetSellAmount();
        Destroy(turret);
        turret_Blueprint = null;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
