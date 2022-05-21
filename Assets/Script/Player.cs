using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private Animator animator;

    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Debug.Log(x);
        //Debug.Log(y);


        //รีเซ็ตการเดินให้เป็น 0
        moveDelta = new Vector3(x, y, 0);

        //ให้ตัวละครหันหน้า
        if (moveDelta.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //ให้ตัวละครเดินได้ WASD
        //transform.Translate(moveDelta * Time.deltaTime);

        //animation เดินแล้วหยุด
        if (moveDelta.x + y == 0)
        {
            animator.SetBool("Speed", false);
        }
        else
        {
            animator.SetBool("Speed", true);
        }





        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //ให้ตัวละครเดินได้ WASD
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //ให้ตัวละครเดินได้ WASD
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
