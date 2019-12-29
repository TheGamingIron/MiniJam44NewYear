using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    Rigidbody2D playerRigidbody;
    SpriteRenderer sprRender;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprRender = GetComponent<SpriteRenderer>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        
        if (verticalMove < 0.0f)
        {
            playerRigidbody.MovePosition(playerRigidbody.position + Vector2.down * Time.deltaTime * playerSpeed);
            anim.SetBool("hMove", false);
        }
        else if (horizontalMove < 0.0f)
        {
            playerRigidbody.MovePosition(playerRigidbody.position + Vector2.left * Time.deltaTime * playerSpeed);
            sprRender.flipX = false;
            anim.SetBool("hMove", true);
        }
        else if (horizontalMove > 0.0f)
        {
            playerRigidbody.MovePosition(playerRigidbody.position + Vector2.right * Time.deltaTime * playerSpeed);
            sprRender.flipX = true;
            anim.SetBool("hMove", true);
        }
    }
}
