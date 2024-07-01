using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb2d;
    private Vector3 originalScale;
    private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        animator = GetComponent<Animator>();
    }                                         

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(moveHorizontal, 0f, moveVertical).normalized * speed * Time.fixedDeltaTime;

        float absHorizontal = Mathf.Abs(moveHorizontal);
        float absVertical = Mathf.Abs(moveVertical);

        if (absHorizontal > 0 || absVertical > 0) { // should move somewhere...
            if (absHorizontal > absVertical) // if moving both axis, choose higher speed
            {
                // horizontal speed is higher
                animator.SetBool("isMovingSide", true);
                animator.SetBool("isMovingBack", false);
                animator.SetBool("isMovingFront", false);
            } else
            {
                // vertical speed is higher
                animator.SetBool("isMovingSide", false);

                bool showBackward = moveVertical > 0;
                bool showFront = moveVertical < 0;
                animator.SetBool("isMovingBack", showBackward);
                animator.SetBool("isMovingFront", showFront);
            }
        } else { // no movement needed
            animator.SetBool("isMovingFront", false);
            animator.SetBool("isMovingBack", false);
            animator.SetBool("isMovingSide", false);
        }

        TurnAround(moveHorizontal);
    }

    private void TurnAround(float moveHorizontal)
    {
        if(moveHorizontal > 0)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }

        if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
    }

}
