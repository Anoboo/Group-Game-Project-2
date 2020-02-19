using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_with_Collision : MonoBehaviour
{
    public Camera cam;
    public Transform turret;
    public float distanceFromCamera;
    Rigidbody turretRB;

    // Start is called before the first frame update
    void Start()
    {
        distanceFromCamera = Vector3.Distance(turret.position, cam.transform.position);
        turretRB = turret.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = Camera.main.ScreenToWorldPoint(pos);
            turretRB.velocity = (pos - turret.position) * 10;
        }
    }
}
