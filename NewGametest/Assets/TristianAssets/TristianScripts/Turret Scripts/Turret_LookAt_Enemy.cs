using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_LookAt_Enemy : MonoBehaviour
{
    // These are for the rotation of the turret when the enemy enters the trigger
    [SerializeField] private Transform target;
    private Vector3 originalPos;
    private GameObject enemy;
    [SerializeField] private bool inTrigger = false;

    // These are for the bullet
    public GameObject laser;
    public GameObject laserLocation;
    private GameObject laserClone;
    public float shootSpeed;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger == true)
        {
            // If the enemy is in the trigger and is not equal to null it will 
            // get the transform of the enemy and have the turret rotate towards the enemy.
            if (enemy != null)
            {
                target = GameObject.FindGameObjectWithTag("Enemy").transform;
            }
            Vector3 direction = target.position - transform.position;
            Quaternion rotataion = Quaternion.LookRotation(direction);
            transform.rotation = rotataion;

            // This is to spawn the bullet when the turret is locked onto the enemy
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                laserClone = Instantiate(laser, laserLocation.transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                laserClone.GetComponent<Rigidbody>().velocity = transform.forward * shootSpeed;
                spawnTimer = 1f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            inTrigger = false;
        }
    }
}
