using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombies_Attacking_Turrets : MonoBehaviour
{
    // These are for the turret lock on
    public static Transform target;
    public float range = 15f;
    public string turretTag = "Turret";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    // Zombie attacking turrets
    public Vector3 turretPositionOffset;
    //[SerializeField] private bool hasTarget = false;
    public static bool hasTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //InvokeRepeating("AttackingTurret", 0f, 3f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(turretTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            NavMeshAgent agent = this.GetComponent<NavMeshAgent>();
            agent.SetDestination(GameObject.FindGameObjectWithTag("Turret").transform.position);
            hasTarget = true;
            ZombieOffsetToTurret();
        }
        else
        {
            NavMeshAgent agent = this.GetComponent<NavMeshAgent>();
            agent.SetDestination(GameObject.FindGameObjectWithTag("Tower").transform.position);
            hasTarget = false;
        }
        LockOnTarget();
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public Vector3 ZombieOffsetToTurret()
    {
        return target.position + turretPositionOffset;
    }

    /*private void AttackingTurret()
    {
        if (target != null && hasTarget == true)
        {
            MovingTurretHealth.movingTurretHealth--;
        } 
        Debug.Log("Health has been taken from the turret! " + MovingTurretHealth.movingTurretHealth);
    }*/
}
