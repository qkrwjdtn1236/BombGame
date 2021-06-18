using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public Transform target;
    private Rigidbody rig;
    public float speed = 100f;
    public AudioSource enermyAudio;
    public GameObject explosionEffect;

    private bool scored = false;
    // Start is called before the first frame update
    void Start()
    {
        enermyAudio = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < 10f)
        {
            Vector3 trans = target.position - transform.position;
            rig.AddForce(trans* speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && scored == false)
        {
            enermyAudio.Play();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            scored = true;
            GameManager.instance.AddScore(1);
            transform.position = new Vector3(Random.Range(-30, 30), 5.5f, Random.Range(-30, 30));
            scored = false;
        }

    }
}
