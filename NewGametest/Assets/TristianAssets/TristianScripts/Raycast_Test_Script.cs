using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Test_Script : MonoBehaviour
{
    public bool turretIsClicked;
    public Camera cmera;
    //private GameObject turret;
    BasicMovementForTurret turret;
    // Start is called before the first frame update
    void Start()
    {
        turretIsClicked = false;
        turret = GetComponent<BasicMovementForTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Test")
                {
                    Debug.Log("This is the Test.");
                    turretIsClicked = true;
                }
                else
                {
                    Debug.Log("This is not the Test.");
                    turretIsClicked = false;
                }
            }
        }
        if (turretIsClicked == true)
        {
            turret.enabled = true;
        }
        else if (turretIsClicked == false)
        {
            turret.enabled = false;
        }
    }
}
