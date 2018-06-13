using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {

    Animation anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}

    public void PlayAnim()
    {
        anim.Play();
    }
}
