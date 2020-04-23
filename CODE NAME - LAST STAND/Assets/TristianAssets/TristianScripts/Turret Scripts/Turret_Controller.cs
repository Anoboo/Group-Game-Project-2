using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Controller : MonoBehaviour
{
    public GameObject Turret;
    private GameObject turretControllerRef;

    // Start is called before the first frame update
    void Start()
    {
        turretControllerRef = GameObject.FindGameObjectWithTag("Turret");    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MouseDown");
            // Reset ray with new mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.tag == "Turret")
                {
                    Turret = hit.collider.gameObject;
                    Debug.Log(Turret);
                    Debug.Log("Hit");
                    /*if(Turret == hit.collider.gameObject)
                    {
                        turretControllerRef.GetComponent<BasicMovementForTurret>().enabled = true;
                        turretControllerRef.GetComponent<CharacterController>().enabled = true;
                    }*/
                }
                /*else if(hit.collider.gameObject.tag != "Turret")
                {
                    turretControllerRef.GetComponent<BasicMovementForTurret>().enabled = false;
                    turretControllerRef.GetComponent<CharacterController>().enabled = false;
                }*/
            }
        }
    }
}
