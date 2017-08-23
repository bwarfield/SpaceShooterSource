using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    private float startTime;
    private float lastShot;
    public float fireRate;
    public float delay;
     
    private AudioSource audioShot;



	// Use this for initialization
	void Start () {
        audioShot = GetComponent<AudioSource>();
        startTime += Time.time;
        lastShot = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > startTime + delay && Time.time > lastShot + fireRate)
        {
            lastShot = Time.time;
            fire();
  
        }
	}

    void fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioShot.Play();
    }
}
