using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour {

    public static GameObject grass, tree, rock, rail, coin, player, road;
    //public static GameObject[,] terrainArray = new GameObject[21, 50];
    public static List<List<GameObject>> terrainArray = new List<List<GameObject>>();
    public static List<List<GameObject>> coinArray = new List<List<GameObject>>();
    public UnityEngine.UI.Text coinText;
    public static AudioClip music;
    public AudioClip mainMusic;
    public static bool snowPurchase, desertPurchase;
    public static bool terrainBool;
    public static int points;

    public static int x, z;

    // Use this for initialization
    void Start() {
        //This sets the terrain to not be generated.
        terrainBool = false;

        //This sets the level purchases to be false.
        snowPurchase = false;
        desertPurchase = false;

        //This sets the points to be zero.
        points = 0;
        player = gameObject;

        x = 0;
        z = 0;
        for (int counter = 0; counter < 21; counter++)
        {
            coinArray.Add(new List<GameObject>());
            terrainArray.Add(new List<GameObject>());
            for (int counter2 = 0; counter2 < 40; counter2++)
            {
                terrainArray[counter].Add(null);
                coinArray[counter].Add(null);
            }
        }
        Random.seed = System.DateTime.Now.Millisecond;
    }

    void Update()
    {/*
        //This checks if the player won.
        if (transform.position.z >= 49)
        {
            //This teleports the player to the menu.
            transform.position = new Vector3(5, 25, 0);


            //This sets and plays the menu music.
            player.GetComponent<AudioSource>().clip = mainMusic;
            playMusic();
        }*/
    }

    //This function plays the music after connecting the clip to the source.
    public void playMusic()
    {
        AudioSource music = GetComponent<AudioSource>();
        music.Play();
    }

    //This function generates the terrain.
    public int Generate()
    {

        if (x == 21)
        {
            x = 0;
            z++;
        }

        int terrainType = Random.Range(0, 100);
        //terrainType = 4;
        if (terrainType == 0)
        {
            int returnInt = 21;
            //Rails, road, river?
            int dangerType = Random.Range(0, 2);
            if (dangerType == 0)
            {
                //Train
                for (int counter = 0; counter < 21; counter++)
                {
                    int rand = Random.Range(0, 75);
                    if (rand == 0)
                    {
                        coinArray[counter][z] = Instantiate(coin, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 90));
                        coinArray[counter][z].GetComponent<SpinCoin>().player = player;
                        coinArray[counter][z].GetComponent<SpinCoin>().coinText = coinText;
                    }

                    if (terrainArray[counter][z] != null)
                    {
                        returnInt--;
                        Destroy(terrainArray[counter][z], 0);
                    }
                    terrainArray[counter][z] = Instantiate(rail, new Vector3(counter, 0, z), Quaternion.Euler(-90, 0, 0));
                    terrainArray[counter][z].GetComponent<SpawnTrain>().player = player;
                }
                x = 0;
                z++;
            }
            else
            {
                //car
                for (int counter = 0; counter < 21; counter++)
                {
                    int rand = Random.Range(0, 75);
                    if (rand == 0)
                    {
                        coinArray[counter][z] = Instantiate(coin, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 90));
                        coinArray[counter][z].GetComponent<SpinCoin>().player = player;
                        coinArray[counter][z].GetComponent<SpinCoin>().coinText = coinText;
                    }

                    if (terrainArray[counter][z] != null)
                    {
                        returnInt--;
                        Destroy(terrainArray[counter][z], 0);
                    }
                    terrainArray[counter][z] = Instantiate(road, new Vector3(counter, 0, z), Quaternion.Euler(-90, 90, 0));
                    terrainArray[counter][z].GetComponent<spawnCar>().player = player;
                }
                x = 0;
                z++;
            }
            return returnInt;
        }
        else
        {
            //Land and obstacles.
            int randInt = Random.Range(0, 15);
            if (randInt == 0)
            {
                //Plant
                terrainArray[x][z] = Instantiate(tree, new Vector3(x, 0, z), Quaternion.Euler(-90, 0, 0));
            }
            else if (randInt == 1)
            {
                //Obstacle
                terrainArray[x][z] = Instantiate(rock, new Vector3(x, 0, z), Quaternion.Euler(-90, 0, 0));
            }
            else
            {
                int rand = Random.Range(0, 75);
                if (rand == 0)
                {
                    coinArray[x][z] = Instantiate(coin, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 90));
                    coinArray[x][z].GetComponent<SpinCoin>().player = player;
                    coinArray[x][z].GetComponent<SpinCoin>().coinText = coinText;
                }
                //Land
                terrainArray[x][z] = Instantiate(grass, new Vector3(x, 0, z), Quaternion.Euler(-90, 0, 0));
            }
            x++;
            return 1;
        }
    }

    public void Initial(int num){
        int counter = num;
        while(counter > 0)
        {
            counter = counter - Generate();
        }

        for (int counter2 = 0; counter2 < 21; counter2++) {
            Destroy(terrainArray[counter2][0], 0);
            terrainArray[counter2][0] = Instantiate(grass, new Vector3(counter2, 0, 0), Quaternion.Euler(-90, 0, 0));
        }

        //This sets the terrain generation to true.
        terrainBool = true;
    }
    
    //This is the function that deletes the terrain.
    public void Delete()
    {
        for (int counter1 = 0; counter1 < 21; counter1++)
        {
            for (int counter2 = 0; counter2 <= z; counter2++)
            {
                if (terrainArray[counter1][counter2] != null)
                {
                    Destroy(terrainArray[counter1][counter2], 0);
                }
                if (coinArray[counter1][counter2] != null)
                {
                    Destroy(coinArray[counter1][counter2], 0);
                }
            }
        }

        terrainArray = new List<List<GameObject>>();
        coinArray = new List<List<GameObject>>();
        x = 0;
        z = 0;
        for (int counter = 0; counter < 21; counter++)
        {
            coinArray.Add(new List<GameObject>());
            terrainArray.Add(new List<GameObject>());
            for (int counter2 = 0; counter2 < 40; counter2++)
            {
                terrainArray[counter].Add(null);
                coinArray[counter].Add(null);
            }
        }
        Random.seed = System.DateTime.Now.Millisecond;

        //This sets the terrain to be not generated.
        terrainBool = false;
    }

    //This function resets the player back to the beginning of the map.
    public void ResetPlayer()
    {
        transform.position = new Vector3(10, 1, 0);
    }
}