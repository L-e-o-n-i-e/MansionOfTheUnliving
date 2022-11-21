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
    AudioSource audioSource;
    private float turnspeed = 2f;
    public bool action = false;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<Agent>();
        audioSource = GetComponent<AudioSource>();
    }
    public void Start()
    {
        playerCamera = Camera.main;
        // playerCamera = GetComponentInChildren<Camera>();
    }

    public void Update()
    {
        if (action)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }
    public void FixedUpdate()
    {
        Vector3 targetPos = agent.followTarget.position;

        if (Vector3.Distance(transform.position, targetPos) <= 1)
        {
            SetProperAngle();
        }
    }

    public void Shoot()
    {
        //TODO
        //If player bullet hits an enemy, it makes a squish sound, if it misses, it makes a miss sound.
               
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
      
            string tag = hit.transform.tag;
            Debug.Log(tag + "hit");

            EnemyManager.Instance.GotHit(hit.transform, tag);

            //if (hit.transform.tag == "Zombie")
            //{
            //    EnemyManager.Instance.GotHit( hit.transform, "Zombie");
            //}
            //else if (hit.transform.tag == "BreakDancer")
            //{
            //    EnemyManager.Instance.GotHit( hit.transform, "BreakDancer");

            //}
            //else if(hit.transform.tag == "HeadZombie")
            //{
            //    EnemyManager.Instance.GotHit( hit.transform, "HeadZombie");

            //}
            //else if (hit.transform.tag == "HeadBreakDancer")
            //{
            //    EnemyManager.Instance.GotHit( hit.transform, "HeadBreakDancer");
            //}
            //else
            //{
                audioSource.Play();
            
        }
    }

    public void MoveTowards(Transform targetPos)
    {
        agent.followTarget = targetPos;


    }

    public void SetProperAngle()
    {
        if (transform.localRotation != agent.followTarget.localRotation)
        {
            Vector3 targetRotation = agent.followTarget.transform.rotation.eulerAngles;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.fixedDeltaTime * turnspeed);
        }
        else
        {
            PlayerManager.Instance.hasArrived = true;
        }
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }
}