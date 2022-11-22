using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDancer :MonoBehaviour
{
    Animator animator;
    EnemyType Zombie;
    Transform target;
    public AmmoBox boxPrefab;
    public float START_HP = 1000;
    float currentHp = 1000;
    float TimeBeforeDisapear = 2;
    float TimeToDisapear;
    bool dead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = GetComponent<Agent>().followTarget.transform;
       
    }
    private void Update()
    {
        if (dead && Time.time >= TimeToDisapear)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        animator.SetFloat("TargetDistance", distance);

        if(distance < 2f)
        {
            EnemyManager.Instance.HitPlayer();
        }
    }

    public float GetCurrentHp()
    {
        return currentHp;
    }

    public bool GetDmg(string tag)
    {
        currentHp--;
        //Debug.Log(name + "Got hit :  currentHp = " + currentHp);

        if (currentHp <= 0 | tag == "HeadBreakDancer")
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
