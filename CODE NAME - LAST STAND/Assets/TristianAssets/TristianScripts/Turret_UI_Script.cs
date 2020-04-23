using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Turret_UI_Script : MonoBehaviour
{
    public GameObject UI;

    public Text upgradeCost;
    public Button UpgradeButton;

    public Text SellAmount;

    public bool UpgradeisDone;

    private Base_Turret_Placements target;

    public void SetTarget(Base_Turret_Placements _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();


        if (!target.isUpgraded)
        {

            upgradeCost.text = "$" + target.turret_Blueprint.upgradeCost;
            UpgradeisDone = true;
            UpgradeButton.interactable = false;
        }

        else
        {


            upgradeCost.text = "DONE";

            UpgradeButton.interactable = true;
        }

        if (UpgradeisDone == true)
        {

        }

        UI.SetActive(true);

        SellAmount.text = "$" + target.turret_Blueprint.GetSellAmount();

    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectTurret();

    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectTurret();
        target.isUpgraded = false;
    }
}
