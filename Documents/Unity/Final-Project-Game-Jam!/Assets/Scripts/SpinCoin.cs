using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCoin : MonoBehaviour {

    public GameObject player;
    public UnityEngine.UI.Text coinText;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Player" || other.GetComponent<Collider>().name == "Controller (left)" || other.GetComponent<Collider>().name == "Controller (right)")
        {
            //This increase the points.
            GenerateTerrain.points++;

            //This updates the money text.
            coinText.text = GenerateTerrain.points.ToString();

            //This destroys the coin.
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {

        //This rotates the coins.
        transform.Rotate(Vector3.right * Time.deltaTime * 40);
    }
}