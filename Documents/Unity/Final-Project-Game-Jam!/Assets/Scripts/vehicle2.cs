using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicle2 : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        //This moves the car forward.
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
    }
}
