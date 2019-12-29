using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmBar : MonoBehaviour
{
    Animator anim;
    float timer;
    public RythmManager rythmManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    private void Update()
    {
        if (anim.enabled)
        {
            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
            timer += Time.deltaTime;
            if (timer > info.length)
            {
                anim.enabled = false;
                timer = 0.0f;
            }
        }
    }

    public void CollidedWith()
    {
        anim.enabled = true;
        rythmManager.IncrementScore();
    }

}
