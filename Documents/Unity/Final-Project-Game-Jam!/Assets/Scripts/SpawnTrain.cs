using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrain : MonoBehaviour {

    public GameObject train, player;

	// Update is called once per frame
	void Start () {
        //This starts spawning trains for the rail block that is on the left side.
        if (transform.position.x == 0)
        {
            InvokeRepeating("spawn", 2, 10);
        }
	}

    void spawn()
    {
        //This generates a car at a set interval.
        GameObject temp = Instantiate(train, new Vector3(transform.position.x, 1.25f, transform.position.z), Quaternion.Euler(0, 90, 0));
        Destroy(temp, 1);
        temp.GetComponent<Car>().player = player;
    }
}
