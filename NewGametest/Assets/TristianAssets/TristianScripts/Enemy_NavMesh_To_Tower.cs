using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavMesh_To_Tower : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        /*NavMeshAgent agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(GameObject.FindGameObjectWithTag("Tower").transform.position);*/
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(GameObject.FindGameObjectWithTag("Tower").transform.position);
    }
}
