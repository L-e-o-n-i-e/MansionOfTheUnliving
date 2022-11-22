using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Animator animator;
    public float START_HP = 2;
    float currentHp = 2;
    Transform target;
    float TimeBeforeDisapear = 2;
    float TimeToDisapear;
    bool dead = false;
    public AmmoBox boxPrefab;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = GetComponent<Agent>().followTarget.transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        animator.SetFloat("TargetDistance", distance);

        if (distance < 2.5f)
        {
            EnemyManager.Instance.HitPlayer();
        }

        if (dead && Time.time >= TimeToDisapear)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
     
    }

    public float GetCurrentHp()
    {
        return currentHp;
    }

    public bool GetDmg(string tag)
    {
        currentHp--;
        //Debug.Log(name + "Got hit :  currentHp = " + currentHp);

        if (currentHp <= 0 | tag == "HeadZombie")
        {
            Dies();
            return true;
        }

        return false;
    }

    public void Dies()
    {
        TimeToDisapear = Time.time + TimeBeforeDisapear;
        animator.SetTrigger("Dead");

        //50% of dropping Ammo
        int nb = Random.Range(0, 2);
        if (nb == 0)
        {
            AmmoBox ammo = GameObject.Instantiate<AmmoBox>(boxPrefab);
            ammo.transform.position = transform.position;
        }

        dead = true;
    }
}
