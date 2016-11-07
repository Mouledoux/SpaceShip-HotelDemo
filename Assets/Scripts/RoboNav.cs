using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoboNav : MonoBehaviour
{
    public GameObject Master;
    [SerializeField] List<AudioClip> soundBites; //0 hello, 1 heyHeyHey, 2 thereYouAre

    NavMeshAgent agent;
    Animator anim;
    bool canSpeak = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        Vector3 target = Master.transform.position - Master.transform.right * 2;
        target.y = transform.position.y;
        agent.destination = target;
        anim.SetFloat("Speed", agent.velocity.magnitude);

        if(Vector3.Distance(transform.position, Master.transform.position) <= 5 && canSpeak)
        {
            StartCoroutine(Speak());
        }
    }

    void PlayStepSound()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator Speak()
    {
        int index = Random.Range(0, 3);
        GetComponent<AudioSource>().PlayOneShot(soundBites[index], 0.3f);

        canSpeak = false;
        float timer = 0;
        while(timer <= 15)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        canSpeak = true;
    }

}
