using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCar : MonoBehaviour {

    public GameObject car, player;

    // Update is called once per frame
    void Start()
    {
        //This starts spawning cars for the road block that is on the right side.
        if (transform.position.x == 10)
        {
            InvokeRepeating("spawn", 0, 1);
        }
    }

    void spawn()
    {
        //This generates a random value.
        int randInt = Random.Range(0, 4);

        //This generates a car at a random interval.
        if (randInt == 0) {
            GameObject temp = Instantiate(car, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.Euler(0, -90, 0));
            Destroy(temp, 2);
            temp.GetComponent<Car>().player = player;
        }
    }
}
