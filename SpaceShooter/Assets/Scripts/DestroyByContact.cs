using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    public int scoreValue;



    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'Game Controller'");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "Boundary" || other.tag == "Enemy")
        if(other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        //Debug.Log(other.name);

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        //if(other.tag == "Player")
        if(other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.gameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.addToScore(scoreValue);
    }

}
