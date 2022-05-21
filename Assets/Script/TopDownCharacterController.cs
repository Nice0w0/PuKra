using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private BoxCollider2D boxCollider;

        private Animator animator;

        private Vector3 moveDelta;

        public float moveSpeed;

        private RaycastHit2D hit;

        private void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
        }


        private void Update()
        {

            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("Speed", dir.magnitude > 0);

            
           
        }
        private void FixedUpdate()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            moveDelta = new Vector3(x, y, 0);

            if (moveDelta.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
                
            else if (moveDelta.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
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
    
}
