using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{
    public float timer = 0.0f;
    public GameObject childTarget;
    bool exploded = false;
    float randomExplodeTime;

    public  ExplosionMaker curMaker;
    AudioSource audioSource;
    SpriteRenderer sprRender;
    CircleCollider2D cCol;
    Animator curAnim;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sprRender = GetComponent<SpriteRenderer>();
        curAnim = GetComponent<Animator>();
        cCol = GetComponent<CircleCollider2D>();

        randomExplodeTime = Random.Range(1.0f, 2.5f);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (!exploded)
        {
            if (timer >= randomExplodeTime)
            {
                sprRender.enabled = true;
                curAnim.enabled = true;
                cCol.enabled = true;
                audioSource.Play();
                Camera.main.GetComponent<CameraShake>().BeginShake();
                timer = 0.0f;
                exploded = true;
                childTarget.SetActive(false);
            }
        }
        else
        {
            if (timer >= 2.5f)
            {
                gameObject.SetActive(false);
                sprRender.enabled = false;
                curAnim.enabled = false;
                cCol.enabled = false;
                Camera.main.GetComponent<CameraShake>().BeginShake();
                randomExplodeTime = Random.Range(1.0f, 2.5f);
                timer = 0.0f;
                exploded = false;
                childTarget.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.position = new Vector3(0, 10, 0);
            
            curMaker.RestartGame();
        }
    }

}
