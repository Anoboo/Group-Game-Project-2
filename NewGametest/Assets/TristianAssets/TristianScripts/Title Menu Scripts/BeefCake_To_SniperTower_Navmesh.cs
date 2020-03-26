using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeefCake_To_SniperTower_Navmesh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(GameObject.FindGameObjectWithTag("Turret").transform.position);
    }
}
