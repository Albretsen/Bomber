using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject explosionPrefab;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(Vector2 dir)
    {
        var explodingPlayer = (GameObject)Instantiate(explosionPrefab, rb.position, transform.rotation);
        Destroy(gameObject);
    }
}
