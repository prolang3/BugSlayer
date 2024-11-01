using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float MaxVelocity = 5;
    public float Acceraction = 1;
    public float Deceleration = .1f;
    public float JumpPower = 5;
    public float JumpHoldDuration = 0.5f;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D box;
    private HealthComponent health;

    private float timeAfterJump;

    private bool isGrounded = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        //Health = MaxHealth;
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        health = GetComponent<HealthComponent>();

        health.Health = health.MaxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }

        if (isJumping)
        {
            if (timeAfterJump < JumpHoldDuration)
            {
                timeAfterJump += Time.deltaTime;
            }
            else
            {
                StopJumping();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                body.velocity = new(body.velocity.x, JumpPower);
            }
            else
            {
                StopJumping();
            }
        }

        float veloX = 0;

        if (Input.GetKey(KeyCode.A))
        {
            veloX -= Acceraction;
        }
        if (Input.GetKey(KeyCode.D))
        {
            veloX +=  Acceraction;
        }

        if (veloX == 0)
        {
            if (body.velocity.x > 0)
            {
                if (body.velocity.x + -Deceleration < 0)
                {
                    veloX = -body.velocity.x;
                }
                else
                {
                    veloX = -Deceleration;
                }
            }
            if (body.velocity.x < 0)
            {
                if (body.velocity.x + Deceleration > 0)
                {
                    veloX = -body.velocity.x;
                }
                else
                {
                    veloX = Deceleration;
                }
            }
        }

        body.velocity = new(Mathf.Clamp(body.velocity.x + veloX, -MaxVelocity, MaxVelocity), body.velocity.y);
    }

    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (box.bounds.extents.y + 0.1f) * Vector3.down, -Vector3.up, 0.1f);
        if(hit)
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
            if (isJumping && timeAfterJump != 0 && timeAfterJump > 0.1f)
            {
                StopJumping();
            }
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

        void StopJumping()
    {
        isJumping = false;
        timeAfterJump = 0;

        Debug.Log("Jump ended");
    }
}
