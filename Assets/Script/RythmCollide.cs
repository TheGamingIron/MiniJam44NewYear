using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmCollide : MonoBehaviour
{

    public float rhythmSpeed = 500.0f;
    public int stripIndex = 0;
    Rigidbody2D rigid;
    RhythmBar curBar;

    bool inTrigger = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (inTrigger)
        {
           
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(0, -rhythmSpeed) * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
           curBar = collision.GetComponent<RhythmBar>();

        
        if (curBar != null)
        {
            if (Input.GetKeyDown(KeyCode.S) && stripIndex == 1)
            {
                gameObject.SetActive(false);
                curBar.CollidedWith();

            }
            else if (Input.GetKeyDown(KeyCode.A) && stripIndex == 0)
            {
                gameObject.SetActive(false);
                curBar.CollidedWith();
            }
            else if (Input.GetKeyDown(KeyCode.D) && stripIndex == 2)
            {
                gameObject.SetActive(false);
                curBar.CollidedWith();
            }
        }
    }

}
