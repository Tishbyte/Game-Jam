using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //This moves the train forward.
        transform.Translate(Vector3.forward * Time.deltaTime * 10);	
	}
}
