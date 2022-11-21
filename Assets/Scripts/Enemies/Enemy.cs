using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType { Zombie, BreakDancer}
public class Enemy : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 headPosition;
    float START_HP;
    float currentHp;


    public float GetCurrentHp()
    {
        return currentHp;
    }

}





