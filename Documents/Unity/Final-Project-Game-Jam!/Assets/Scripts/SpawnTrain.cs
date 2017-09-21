using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrain : MonoBehaviour {

    public GameObject train, player;

	// Update is called once per frame
	void Start () {
        Random.seed = System.DateTime.Now.Millisecond;

        //This starts spawning trains for the rail block that is on the left side.
        if (transform.position.x == 0)
        {
            InvokeRepeating("spawn", 2, 10);
        }
	}

    void spawn()
    {
        int randInt = Random.Range(0, 4);

        //This generates a car at a random interval.
        if (randInt == 0)
        {
            GameObject temp = Instantiate(train, new Vector3(transform.position.x, 1.25f, transform.position.z), Quaternion.Euler(0, 90, 0));
            Destroy(temp, 2);
            temp.GetComponent<Car>().player = player;
        }
    }
}
