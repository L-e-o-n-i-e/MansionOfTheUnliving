using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    Camera playerCamera;
    NavMeshAgent agent;

    void Start()
    {
        playerCamera = Camera.main;
       // playerCamera = GetComponentInChildren<Camera>();
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        //Will become the logic for clicking on the screen to kill enemies
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 PointHit = hit.point;
            agent.SetDestination(PointHit);
        }
    }    
}