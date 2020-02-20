using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turret_NavMesh_To_Mouse_Position : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    [SerializeField] private int isMouseClicked;
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isMouseClicked == 0)
            {
                isMouseClicked = 1;
            }     
        }

        if (Input.GetKey(KeyCode.R) && isMouseClicked == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetDestinationToMousePosition();
            }
        }

        if (Input.GetMouseButtonDown(1) && isMouseClicked == 1)
        {
            isMouseClicked = 0;
        }
    }

    public void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            myNavMeshAgent.SetDestination(hit.point);
        }
    }
}
