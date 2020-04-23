using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_and_Drag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject turretRef;
    private bool IsClicked;

    // Start is called before the first frame update
    void Start()
    {
        turretRef = GameObject.FindGameObjectWithTag("Turret");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsClicked = true;
            turretRef.GetComponent<Turret_Shoot>().enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsClicked = false;
            turretRef.GetComponent<Turret_Shoot>().enabled = true;
        }

        if (IsClicked == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.Rotate(0f, 90f, 0, Space.Self);
            }
        }
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            print("Collision Detected");
        }
    }
}
