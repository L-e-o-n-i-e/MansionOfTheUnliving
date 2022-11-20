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
    Agent agent;
    Rigidbody rb;
    private float speed = 2;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<Agent>();
    }
    public void Start()
    {
        playerCamera = Camera.main;
        // playerCamera = GetComponentInChildren<Camera>();
    }

    public void Update()
    {
        Vector3 targetPos = agent.followTarget.position;

        if (Vector3.Distance(transform.position, targetPos) <= 1)
        {
            Debug.Log("Made it to check point");

            transform.transform.localRotation = agent.followTarget.localRotation;
        }


        //Will become the logic for clicking on the screen to kill enemies
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 PointHit = hit.point;
            //agent.SetDestination(PointHit);
        }

        //INPUT MouseClick

    }
    public void Shoot()
    {

    }


    public void MoveTowards(Transform targetPos)
    {
        agent.followTarget = targetPos;


    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }
}