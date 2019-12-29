using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float playerSpeed = 50.0f;
    float pHorizontal, pVertical;
    bool canJump = true;
    AudioSource audioSrc;
    Rigidbody2D curRigid;
  
    private void Awake()
    {
        curRigid = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }


    private void Update()
    {
        pHorizontal = Input.GetAxisRaw("Horizontal");        
        if (Input.GetKeyDown(KeyCode.S) && canJump)
        {
            curRigid.velocity = new Vector2(curRigid.velocity.x, 5);
            canJump = false;
            audioSrc.Play();
        }
        if (transform.position.y < -20)
        {
            transform.position = new Vector3(-60, -1.03f, 0);
        }
    }
    private void FixedUpdate()
    {
        float yVel = curRigid.velocity.y;
        curRigid.velocity = new Vector2(pHorizontal, 0) * Time.deltaTime * playerSpeed;
        curRigid.velocity = new Vector2(curRigid.velocity.x, yVel);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }


}
