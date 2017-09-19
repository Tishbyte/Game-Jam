using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDetect : MonoBehaviour {

    public GameObject grass, tree, rock, rail, snow, snowRail, pine, present, leftHand, rightHand, player, coin, chocolate, road,
        sand, sandRail, skull, cactus;
    public string menuChoice;
    public AudioClip desertMusic, snowMusic, grassMusic;

    // Update is called once per frame
    void Update() {

        //This checks if the terrain is already generated or not.
        if (GenerateTerrain.terrainBool == false) {

            //This checks if the user touches a block.
            if (leftHand.transform.position.x >= transform.position.x - transform.localScale.x / 2 &&
            leftHand.transform.position.x <= transform.position.x + transform.localScale.x / 2 &&
            leftHand.transform.position.z >= transform.position.z - transform.localScale.z / 2 &&
            leftHand.transform.position.z <= transform.position.z + transform.localScale.z / 2)
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
                    player.GetComponent<GenerateTerrain>().playMusic();

                    //This makes the terrain generate.
                    player.GetComponent<GenerateTerrain>().Generate();
                    //This tps the player to the right spot.
                    player.transform.position = new Vector3(5, 1, 0);
                }
                else if (menuChoice == "grass")
                {
                    GenerateTerrain.grass = grass;
                    GenerateTerrain.tree = tree;
                    GenerateTerrain.rail = rail;
                    GenerateTerrain.rock = rock;
                    GenerateTerrain.coin = coin;
                    GenerateTerrain.road = road;
                    player.GetComponent<AudioSource>().clip = grassMusic;
                    player.GetComponent<GenerateTerrain>().playMusic();
                    player.GetComponent<GenerateTerrain>().Generate();
                    player.transform.position = new Vector3(5, 1, 0);
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
                    player.GetComponent<GenerateTerrain>().playMusic();
                    player.GetComponent<GenerateTerrain>().Generate();
                    player.transform.position = new Vector3(5, 1, 0);
                }
            }
            else if (rightHand.transform.position.x >= transform.position.x - transform.localScale.x / 2 &&
            rightHand.transform.position.x <= transform.position.x + transform.localScale.x / 2 &&
            rightHand.transform.position.z >= transform.position.z - transform.localScale.z / 2 &&
            rightHand.transform.position.z <= transform.position.z + transform.localScale.z / 2)
            {
                if (menuChoice == "snow" && GenerateTerrain.snowPurchase)
                {
                    GenerateTerrain.grass = snow;
                    GenerateTerrain.tree = pine;
                    GenerateTerrain.rail = snowRail;
                    GenerateTerrain.rock = present;
                    GenerateTerrain.coin = chocolate;
                    GenerateTerrain.road = road;
                    player.GetComponent<AudioSource>().clip = snowMusic;
                    player.GetComponent<GenerateTerrain>().playMusic();
                    player.GetComponent<GenerateTerrain>().Generate();
                    player.transform.position = new Vector3(5, 1, 0);
                }
                else if (menuChoice == "grass")
                {
                    GenerateTerrain.grass = grass;
                    GenerateTerrain.tree = tree;
                    GenerateTerrain.rail = rail;
                    GenerateTerrain.rock = rock;
                    GenerateTerrain.coin = coin;
                    GenerateTerrain.road = road;
                    player.GetComponent<AudioSource>().clip = grassMusic;
                    player.GetComponent<GenerateTerrain>().playMusic();
                    player.GetComponent<GenerateTerrain>().Generate();
                    player.transform.position = new Vector3(5, 1, 0);
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
                    player.GetComponent<GenerateTerrain>().playMusic();
                    player.GetComponent<GenerateTerrain>().Generate();
                    player.transform.position = new Vector3(5, 1, 0);
                }
            }
        }
    }
}
