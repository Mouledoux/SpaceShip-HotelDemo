using UnityEngine;
using System.Collections;

public class AutoOpenDoor : MonoBehaviour
{
    Animator anim;
    //AudioSource audio;

    void Start()
    {
        anim = GetComponent<Animator>();
        //audio = GetComponent<AudioSource>();
    }

    [ContextMenu("Open door")]
    public void Test()
    {
        anim.SetBool("PlayerNear", true);
        //audio.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("PlayerNear", true);
            //audio.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("PlayerNear", false);
            //audio.Play();
        }
    }
}
