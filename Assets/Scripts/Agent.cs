using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public Transform followTarget;
    NavMeshAgent agent;
  
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(followTarget.position);
        //if problem with error agent not touching the floor ;
        agent.Move(-transform.position);
    }
}