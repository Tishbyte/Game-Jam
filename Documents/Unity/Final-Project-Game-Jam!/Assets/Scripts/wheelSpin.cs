using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelSpin : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        //This rotates the wheels.
        transform.Rotate(Vector3.right * Time.deltaTime * 100);
    }
}
