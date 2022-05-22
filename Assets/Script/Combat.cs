using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator animator;
    private Transform attackPoint;
    private float attackR = 0.5f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Attack();
        //}
    }
    void Attack()
    {
        animator.SetTrigger("Attack1");
    }
}
