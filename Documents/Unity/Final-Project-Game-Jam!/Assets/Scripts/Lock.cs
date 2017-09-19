using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    public GameObject leftHand, rightHand;
    public string lockVal;
    public UnityEngine.UI.Text coinText;


    // Update is called once per frame
    void Update()
    {
        //This detects if the player touches the locks.
        if (leftHand.transform.position.x >= transform.position.x - transform.lossyScale.x / 2 &&
            leftHand.transform.position.x <= transform.position.x + transform.lossyScale.x / 2 &&
            leftHand.transform.position.z >= transform.position.z - transform.lossyScale.z / 2 &&
            leftHand.transform.position.z <= transform.position.z + transform.lossyScale.z / 2)
        {
            //This checks which lock the player touches.
            if (lockVal == "snow")
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
                    Destroy(gameObject, 0);
                }
            }
            else if (lockVal == "desert")
            {
                if (GenerateTerrain.points >= 50)
                {
                    GenerateTerrain.points = GenerateTerrain.points - 50;
                    coinText.text = GenerateTerrain.points.ToString();
                    GenerateTerrain.desertPurchase = true;
                    Destroy(gameObject, 0);
                }
            }
        }
        else if (rightHand.transform.position.x >= transform.position.x - transform.lossyScale.x / 2 &&
            rightHand.transform.position.x <= transform.position.x + transform.lossyScale.x / 2 &&
            rightHand.transform.position.z >= transform.position.z - transform.lossyScale.z / 2 &&
            rightHand.transform.position.z <= transform.position.z + transform.lossyScale.z / 2)
        {
            if (lockVal == "snow")
            {
                if (GenerateTerrain.points >= 25)
                {
                    GenerateTerrain.points = GenerateTerrain.points - 25;
                    coinText.text = GenerateTerrain.points.ToString();
                    GenerateTerrain.snowPurchase = true;
                    Destroy(gameObject, 0);
                }
            }
            else if (lockVal == "desert")
            {
                if (GenerateTerrain.points >= 50)
                {
                    GenerateTerrain.points = GenerateTerrain.points - 50;
                    coinText.text = GenerateTerrain.points.ToString();
                    GenerateTerrain.desertPurchase = true;
                    Destroy(gameObject, 0);
                }
            }
        }
    }
}