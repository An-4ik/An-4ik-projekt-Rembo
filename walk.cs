using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MoveSpeed = 2f;
    public Vector2 moveVector;

    public Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        walkAnim();
        Reflect();
        Jump();
        chekingGround();

    }

    public bool faseRight;

     void Reflect()
    {
        if ((moveVector.x > 0 && faseRight) || (moveVector.x < 0 && !faseRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faseRight = !faseRight;
        }
    }

    void walkAnim()
    {
        
        
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * MoveSpeed, rb.velocity.y);

        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        
    }

    // Анимация и механика прижка -->

    public float jumpForce = 10;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGraund)
        {
            //rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            rb.AddForce(Vector2.up * jumpForce); //расчитовает физику *желательно

        }
    }

    public bool OnGraund;
    public Transform GraundCheck;
    public float ChekRadius =0.5f;
    public LayerMask Graund;

    void chekingGround()
    {
        OnGraund = Physics2D.OverlapCircle(GraundCheck.position, ChekRadius, Graund);
        anim.SetBool("OnGraund", OnGraund);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(GraundCheck.position, ChekRadius);
    }

}
