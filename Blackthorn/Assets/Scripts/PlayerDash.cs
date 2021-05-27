using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    public float startDashTime;

    private float dashTime;   
    private int direction;
    private int dashCount = 1;

    private float horizontalMove;

    public PlayerMove scriptPlayer;
    Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        dashTime = startDashTime;

    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && dashCount > 0)
            {
                dashCount--;

               
                if (horizontalMove < 0)
                {
                    PlayerMove.anim.SetTrigger("Dash");
                    direction = 1;
                }
                else if (horizontalMove > 0)
                {
                    PlayerMove.anim.SetTrigger("Dash");
                    direction = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {

                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }

        if(scriptPlayer.isGrounded || scriptPlayer.onIce)
        {
            dashCount = 1;
        }

    }
}
