using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D c)
    {
        //LOADS NEXT SCENE
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
