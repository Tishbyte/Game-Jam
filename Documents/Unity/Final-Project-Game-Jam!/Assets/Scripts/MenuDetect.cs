using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDetect : MonoBehaviour {

    public GameObject grass, tree, rock, rail, snow, snowRail, pine, present, leftHand, rightHand, player, coin, chocolate, road,
        sand, sandRail, skull, cactus;
    public string menuChoice;
    public AudioClip desertMusic, snowMusic, grassMusic;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Controller (left)" || other.GetComponent<Collider>().name == "Controller (right)")
        {
            //This checks if the terrain is already generated or not.
            if (GenerateTerrain.terrainBool == false)
            {
                //This checks which block is chosen and if it is available.
                if (menuChoice == "snow" && GenerateTerrain.snowPurchase)
                {
                    //This assigns the appropriate prefabs for generation.
                    GenerateTerrain.grass = snow;
                    GenerateTerrain.tree = pine;
                    GenerateTerrain.rail = snowRail;
                    GenerateTerrain.rock = present;
                    GenerateTerrain.coin = chocolate;
                    GenerateTerrain.road = road;

                    //This assigns the appropriate music and plays it.
                    player.GetComponent<AudioSource>().clip = snowMusic;
                }
                else if (menuChoice == "grass")
                {
                    GenerateTerrain.grass = grass;
                    GenerateTerrain.tree = tree;
                    GenerateTerrain.rail = rail;
                    GenerateTerrain.rock = rock;
                    GenerateTerrain.coin = coin;
                    GenerateTerrain.road = road;
                }
                else if (menuChoice == "sand" && GenerateTerrain.desertPurchase)
                {
                    GenerateTerrain.grass = sand;
                    GenerateTerrain.tree = cactus;
                    GenerateTerrain.rail = sandRail;
                    GenerateTerrain.rock = skull;
                    GenerateTerrain.coin = coin;
                    GenerateTerrain.road = road;
                    player.GetComponent<AudioSource>().clip = desertMusic;
                }

                player.GetComponent<GenerateTerrain>().playMusic();
                //This makes the terrain generate.
                player.GetComponent<GenerateTerrain>().Initial(840);
                //This tps the player to the right spot.
                player.transform.position = new Vector3(10, 1, 0);
            }
        }
    }
}