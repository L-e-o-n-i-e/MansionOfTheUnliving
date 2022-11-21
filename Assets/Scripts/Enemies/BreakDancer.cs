using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDancer :MonoBehaviour
{
    Animator animator;
    public float START_HP = 1000;
    float currentHp = 2;
    EnemyType Zombie;
    Transform target;
    float TimeBeforeDisapear = 4;
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

        if(distance < .5f)
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
        dead = true;
    }
}
