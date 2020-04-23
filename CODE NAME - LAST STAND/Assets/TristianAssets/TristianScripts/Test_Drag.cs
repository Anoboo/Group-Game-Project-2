using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Drag : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        // Store reference to attached Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Move by Rigidbody rather than transform directly
        rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
    }

    /*void OnCollisionEnter(Collision col)
    {
        // Freeze on collision
        rb.isKinematic = true;
    }*/
}
