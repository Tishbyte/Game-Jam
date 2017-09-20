using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Car : MonoBehaviour {

    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().name == "Player")
        {
            player.GetComponent<GenerateTerrain>().ResetPlayer();
        }
    }
}