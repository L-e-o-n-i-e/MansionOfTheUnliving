using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType { Zombie, BreakDancer}
public class Enemy : MonoBehaviour
{
    const int intervalOfRandomDir = 5;
    float nextRandTime;
    Vector2 lastRandDir;

    public float speed = .2f;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 headPosition;
    float START_HP;
    float currentHp;


//    public virtual void InitializeUnit()
//    {
//        animator = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody2D>();
//        sr = GetComponent<SpriteRenderer>();
//        //get head position
//    }
    
//    public void UpdateUnit()
//    {
//        Vector2 moveDir = GetMoveDir();
//        UpdateAnimator(moveDir);
//        sr.sortingOrder = (int)(transform.position.y * 10);
//    }

//    public void FixedUpdateUnit()
//    {
//        Vector2 moveDir = GetMoveDir();
//        Move(moveDir);
//    }

//    protected Vector2 GetMoveDir(Vector2 targetPos)
//    {
//     return (targetPos - (Vector2)transform.position).normalized;
        
//            //if (Time.time > nextRandTime)
//            //{
//            //    lastRandDir = Random.insideUnitCircle.normalized;
//            //    nextRandTime = Time.time + intervalOfRandomDir;
//            //}
//            //return lastRandDir;      

//    }

    

//protected virtual void UpdateAnimator(Vector2 dir)
//    {
//        bool yIsGreater = (Mathf.Abs(dir.y) > Mathf.Abs(dir.x));
//        if (yIsGreater)
//        {
//            animator.SetFloat("HorzAxis", 0);
//            animator.SetFloat("VertAxis", dir.y);
//        }
//        else
//        {
//            animator.SetFloat("HorzAxis", dir.x);
//            animator.SetFloat("VertAxis", 0);
//        }

//    }

//    private void Move(Vector2 dir)
//    {
//        rb.velocity = dir.normalized * speed;
//    }

    public float GetCurrentHp()
    {
        return currentHp;
    }

}





