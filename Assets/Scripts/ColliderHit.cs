using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHit : PostProcessBzz
{
    private AudioSource audioSource;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("hhh", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("hhh", true);
            Playhhh();
        }
        else
            animator.SetBool("hhh", false);
    }

    void Playhhh()
    {
        audioSource.Play();
    }
}
