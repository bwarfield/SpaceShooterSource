using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {


    public float tumble;

    private Rigidbody _RB;
	// Use this for initialization
	void Start () {
        _RB = GetComponent<Rigidbody>();

        _RB.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
