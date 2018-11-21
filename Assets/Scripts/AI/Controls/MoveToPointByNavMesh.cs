using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPointByNavMesh : MonoBehaviour {
    public LayerMask hitLayers;
    public GameObject point;
    public bool canControled = true;

    private NavMeshAgent _navMeshAgent;
    private bool _canMove = true;
    public float moveSpeed = 10f;
    // Use this for initialization
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (point != null)
        {
            _navMeshAgent.SetDestination(point.transform.position);
        }
        _navMeshAgent.speed = moveSpeed;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//If the player has left clicked
        {
            if (canControled)
            {
                Vector3 mouse = Input.mousePosition;//Get the mouse Position
                Ray castPoint = Camera.main.ScreenPointToRay(mouse);//Cast a ray to get where the mouse is pointing at
                RaycastHit hit;//Stores the position where the ray hit.
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))//If the raycast doesnt hit a wall
                {
                    if (point != null)
                    {
                        point.transform.position = hit.point;//Move the target to the mouse position
                    }
                }
            }
        }

        if (_canMove && point != null)
        {
            _navMeshAgent.SetDestination(point.transform.position);
        }
    }

    public void StopMove()
    {
        //_canMove = false;
        //_navMeshAgent.speed = 0;
    }

    public void StartMove()
    {
        _canMove = true;
        //_navMeshAgent.speed = moveSpeed;
    }

    public void SetNewPoint(GameObject newPoint)
    {
        point = newPoint;
    }
}
