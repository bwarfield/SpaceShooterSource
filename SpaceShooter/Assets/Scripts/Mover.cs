using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody _RB;
    public float speed;

	// Use this for initialization
	void Start () {
        _RB = GetComponent<Rigidbody>();

        _RB.velocity = transform.forward * speed;
    }
	

}
