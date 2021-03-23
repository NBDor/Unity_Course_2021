using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator anim;
    private AudioSource doorSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) // player or other character's collider
    {
        anim.SetBool("Opening", true);
        doorSound.PlayDelayed(1f);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Opening", false);
        doorSound.PlayDelayed(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
