﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    Vector2 localDirection;
    public static float distance = 1f;
    public static bool playerDead = false;

	// Use this for initialization
	void Start () {
        playerDead = false;
    }

    //STORES A VECTOR2 DIRECTIOM WHICH IS FIRST GIVEN BY THE PLAYERCONTROLLER SCRIPT(1),
    //THEN RETRIEVED BY THE OBJECTIVEEXPLOSION SCRIPT (2)!
    public Vector2 Direction(Vector2 direction, int script)
    {
        if(script == 1)
        {
            localDirection = direction;
            return direction;
        }
        if(script == 2)
        {
            return -localDirection;
        }
        return direction;
    }
}
