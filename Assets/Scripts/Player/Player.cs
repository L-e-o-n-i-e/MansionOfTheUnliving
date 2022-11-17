using UnityEngine;
using UnityEngine.AI;

/*
 Player has hp and ammo
Player cannot control movement or look direction.
Player shoots via clicking the left mouse
Player shooting makes sound effect
If player bullet hits an enemy, it makes a squish sound, if it misses, it makes a miss sound.
 */
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
    
    public void MoveTowards(Transform position)
    {
        //Move the player to make him face that way
        //(B - A).normalized * speed;
        //NavMesh is a good strategy
    }
}