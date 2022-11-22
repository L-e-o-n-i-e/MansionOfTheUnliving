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
        CHeckPointPhase phase = CheckPointManager.Instance.GetCheckPointPhase();

        if (phase == CHeckPointPhase.Moving || phase == CHeckPointPhase.GetInPosition)
        {
            Vector3 targetPos = agent.followTarget.position;

            if (Vector3.Distance(transform.position, targetPos) <= .7f)
            {
                SetProperAngle();
            }
        }
    }

    public void Shoot()
    {
        audioSource.Play();
        UIManager.Instance.LoseAmmo();

        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            string tag = hit.transform.tag;
            Debug.Log(tag + "hit");
            if (tag == "Ammo")
            {
                int nbAmmo = hit.collider.transform.GetComponent<AmmoBox>().nbOfAmmo;
                for (int i = 0; i < nbAmmo; i++)
                {
                    UIManager.Instance.AddAmmo();
                }
                GameObject.Destroy(hit.collider.gameObject);
            }
            EnemyManager.Instance.GotHit(hit.transform, tag);
            //TODO: squish sound       

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
            CheckPointManager.Instance.phase = CHeckPointPhase.GetInPosition;
            PlayerManager.Instance.hasArrived = true;
        }
    }
}