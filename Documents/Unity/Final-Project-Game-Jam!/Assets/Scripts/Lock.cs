using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public UnityEngine.UI.Text coinText;

    void OnTriggerEnter(Collider collide)
    {
        //This checks which lock the player touches.
        if (collide.GetComponent<Collider>().name == "snowLock")
        {
            //This checks if the player has enough money.
            if (GenerateTerrain.points >= 25)
            {
                //This deducts the money from the player.
                GenerateTerrain.points = GenerateTerrain.points - 25;
                //This updates the money text.
                coinText.text = GenerateTerrain.points.ToString();
                //This sets the level to be purchased.
                GenerateTerrain.snowPurchase = true;
                //This removes the lock.
                Destroy(collide.gameObject, 0);
            }
        }
        else if (collide.GetComponent<Collider>().name == "desertLock")
        {
            if (GenerateTerrain.points >= 50)
            {
                GenerateTerrain.points = GenerateTerrain.points - 50;
                coinText.text = GenerateTerrain.points.ToString();
                GenerateTerrain.desertPurchase = true;
                Destroy(collide.gameObject, 0);
            }
        }
    }
}