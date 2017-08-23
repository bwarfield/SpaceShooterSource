using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;

    public float tilt;

    public Boundary gameBoundary;

    public float speed;

    private Rigidbody _RB;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    private void Start()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
            GetComponent<AudioSource>().Play();
        }

   

    }
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        
        movement.Set(moveHorizontal, 0.0f, moveVertical);
        _RB.velocity = movement * speed;

        _RB.position = new Vector3
        (
            Mathf.Clamp(_RB.position.x, gameBoundary.xMin, gameBoundary.xMax),  
            0.0f,
            Mathf.Clamp(_RB.position.z, gameBoundary.zMin, gameBoundary.zMax)
        );


        _RB.rotation = Quaternion.Euler(0.0f, 0.0f, _RB.velocity.x * -tilt);
    }

    public void shoot()
    {

    }

    

}
