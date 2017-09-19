using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCoin : MonoBehaviour {

    public GameObject player;
    public UnityEngine.UI.Text coinText;

    // Update is called once per frame
    void Update () {

        //This rotates the coins.
        transform.Rotate(Vector3.right * Time.deltaTime * 40);

        //This detects if the player touches coins.
        if (player.transform.position.x >= transform.position.x - transform.localScale.x / 2 &&
            player.transform.position.x <= transform.position.x + transform.localScale.x / 2 &&
            player.transform.position.z >= transform.position.z - transform.localScale.z / 2 &&
            player.transform.position.z <= transform.position.z + transform.localScale.z / 2)
        {
            //This increase the points.
            GenerateTerrain.points++;

            //This updates the money text.
            coinText.text = GenerateTerrain.points.ToString();

            //This destroys the coin.
            Destroy(gameObject);
        }
    }
}
