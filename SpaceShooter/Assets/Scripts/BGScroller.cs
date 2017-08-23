using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public float scrollSpeed;
    //public float tileSizeZ;

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        
        transform.position = startPosition + (Vector3.forward * Mathf.Repeat(Time.time * scrollSpeed, GetComponent<Renderer>().bounds.size.z));
    }
}
