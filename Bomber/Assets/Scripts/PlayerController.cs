using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //PUBLIC VARIABLES
    [Header("Movement settings")]
    public float speed;
    public float jumpStrength;
    [Header("Raycast ground check")]
    private Transform GroundCheck;
    [Space(10)]
    public LayerMask WhatIsGround;

    //SCRIPT VARIABLES
    const float GroundedRadius = .2f;
    Vector2 movement;

    //REFERENCES
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        //SETTING UP REFERENCES
        rb = GetComponent<Rigidbody2D>();
        GroundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
        //DETECT HORIZONTAL INPUT
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            HorizontalMovement(Input.GetAxisRaw("Horizontal"));
            //STARTS WALKING ANIMATION
            if (IsGrounded())
            {
                anim.SetInteger("State", 1);
            }
            //FLIPS THE SPRITE RENDERER
            if(Input.GetAxisRaw("Horizontal") < 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
            //MOVE AFTER LANDING
            if(rb.velocity.y > 0.5f || rb.velocity.y < -0.5f)
            {
                if (IsGrounded())
                {
                    anim.SetInteger("State", 2);
                }
            }
        }
        else
        {
            HorizontalMovement(0);
            //STARTS IDLE ANIMATION
            if (IsGrounded())
            {
                anim.SetInteger("State", 0);
            }
        }

        //DETECT VERTICAL INPUT
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            if (IsGrounded())
            {
                Jump();
            }
        }
	}

    //JUMP
    void Jump()
    {
        //STARTS JUMP ANIMATION
        anim.SetInteger("State", 3);
        rb.velocity = new Vector2(rb.velocity.x,jumpStrength);
    }

    //DIRECTION IS THE HORIZONTAL INPUT VALUE (-1 to 1)
    void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("TEST TEST TEST");
            //STARTS IDLE ANIMATION AFTER LANDING
            anim.SetInteger("State", 0);
        }
    }

        //CHECK IF GROUNDED
        bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        Gizmos.color = Color.yellow;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                return true;
        }
        return false;
    }
}
