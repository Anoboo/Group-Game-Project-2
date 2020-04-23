using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Click_and_Control : MonoBehaviour
{
    [SerializeField] private int turretIsClicked = 0;
    //private GameObject turret;
    private BasicMovementForTurret turret;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponent<BasicMovementForTurret>();
        turretIsClicked = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] turretMoving = GameObject.FindGameObjectsWithTag("Turret");
        for (int i = 0; i < turretMoving.Length; i++)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Turret")
                    {
                        Debug.Log("This is a turret.");
                        turretIsClicked = 1;
                    }
                    else
                    {
                        Debug.Log("This is not a turret.");
                        turretIsClicked = 0;
                    }
                }
            }
            if (turretIsClicked == 1)
            {
                turret.enabled = true;
            }
            else if (turretIsClicked == 0)
            {
                turret.enabled = false;
            }
        }
        /*if(Input.GetMouseButtonDown (0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast (ray, out hit))
            {
                if(hit.transform.tag == "Turret")
                {
                    Debug.Log("This is a turret.");
                    turretIsClicked = 1;
                }
                else
                {
                    Debug.Log("This is not a turret.");
                    turretIsClicked = 0;
                }
            }
        }
        if (turretIsClicked == 1)
        {
            turret.GetComponent<BasicMovementForTurret>().enabled = true;
        }

        if (turretIsClicked == 0)
        {
            turret.GetComponent<BasicMovementForTurret>().enabled = false;
        }*/
    }

    void MovingTurret()
    {
        
    }
}
