using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_UI_Script : MonoBehaviour
{
    public GameObject UI;

    private Base_Turret_Placements target;

    public void SetTarget(Base_Turret_Placements _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }
}
