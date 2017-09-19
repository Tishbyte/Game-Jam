using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Car : MonoBehaviour {

    public GameObject player;

	// Update is called once per frame
	void Update () {

        //This code is added to the train and cars to detect collisions and reset the player.
        if (player.transform.position.x >= transform.position.x - transform.localScale.x / 2 && 
            player.transform.position.x <= transform.position.x + transform.localScale.x / 2 &&
            player.transform.position.z >= transform.position.z - transform.localScale.z / 2 &&
            player.transform.position.z <= transform.position.z + transform.localScale.z / 2)
        {
            player.GetComponent<GenerateTerrain>().ResetPlayer();
        }
	}
}
