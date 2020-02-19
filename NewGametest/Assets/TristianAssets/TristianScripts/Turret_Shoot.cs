using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Shoot : MonoBehaviour
{
    public GameObject laser;
    public GameObject laserLocation;
    private GameObject laserClone;
    public float shootSpeed;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            laserClone = Instantiate(laser, laserLocation.transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
            laserClone.GetComponent<Rigidbody>().velocity = -transform.right * shootSpeed;
            spawnTimer = 1f;
        }
    }
}
