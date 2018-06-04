using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

	void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
            playerController.Hit();
            Destroy(gameObject);
        }
        else if(c.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
