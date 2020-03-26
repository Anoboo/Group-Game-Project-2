using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefCake_Look_At_SniperTower : MonoBehaviour
{
    // These are for the turret lock on
    public Transform target;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = turnSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
