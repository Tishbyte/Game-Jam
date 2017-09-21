using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour {

    public static GameObject grass, tree, rock, rail, coin, player, road;
    //public static GameObject[,] terrainArray = new GameObject[21, 50];
    public static List<List<GameObject>> terrainArray = new List<List<GameObject>>();
    public static GameObject[,] coinArray = new GameObject[11, 50];
    public UnityEngine.UI.Text coinText;
    public static AudioClip music;
    public AudioClip mainMusic;
    public static bool snowPurchase, desertPurchase;
    public static bool terrainBool;
    public static int points;

    private int x, y;

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
        y = 0;
        for (int counter = 0; counter < 21; counter++)
        {
            terrainArray.Add(new List<GameObject>());
            for (int counter2 = 0; counter2 < 40; counter2++)
            {
                terrainArray[counter].Add(null);
            }
        }
        Random.seed = System.DateTime.Now.Millisecond;
    }

    void Update()
    {/*
        //This checks if the player won.
        if (transform.position.z >= 49)
        {
            //Debug.Log("You win!");

            //This teleports the player to the menu.
            transform.position = new Vector3(5, 25, 0);

            //This clears the terrain.
            Invoke("Delete", 3);

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
    public void Generate()
    {
        //Debug.Log("X: " + x + " Y: " + y + "/" + terrainArray[x][y]);
        if (x == 20)
        {
            x = 0;
            y++;
        }

        int terrainType = Random.Range(0, 100);

        Debug.Log(terrainType);
        //terrainType = 4;
        if (terrainType == 0)
        {
            //Rails, road, river?
            int dangerType = Random.Range(0, 2);
            if (dangerType == 0)
            {
                //Train
                for (int counter = 0; counter < 21; counter++)
                {
                    if (terrainArray[counter][y] != null)
                    {
                        Destroy(terrainArray[counter][y], 0);
                    }
                    terrainArray[counter][y] = Instantiate(rail, new Vector3(counter, 0, y), Quaternion.Euler(-90, 0, 0));
                    terrainArray[counter][y].GetComponent<SpawnTrain>().player = player;
                }
                x = 0;
                y++;
            }
            else
            {
                //car
                for (int counter = 0; counter < 21; counter++)
                {
                    if (terrainArray[counter][y] != null)
                    {
                        Destroy(terrainArray[counter][y], 0);
                    }
                    terrainArray[counter][y] = Instantiate(road, new Vector3(counter, 0, y), Quaternion.Euler(-90, 0, 0));
                    terrainArray[counter][y].GetComponent<spawnCar>().player = player;
                }
                x = 0;
                y++;
            }
        }
        else
        {
            //Land and obstacles.
            int randInt = Random.Range(0, 15);
            if (randInt == 0)
            {
                //Plant
                terrainArray[x][y] = Instantiate(tree, new Vector3(x, 0, y), Quaternion.Euler(-90, 0, 0));
            }
            else if (randInt == 1)
            {
                //Obstacle
                terrainArray[x][y] = Instantiate(rock, new Vector3(x, 0, y), Quaternion.Euler(-90, 0, 0));
            }
            else
            {
                //Land
                terrainArray[x][y] = Instantiate(grass, new Vector3(x, 0, y), Quaternion.Euler(-90, 0, 0));
            }
            x++;
        }


        /*int randInt;

        for (int counter1 = 0; counter1 < 11; counter1++)
        {
            for (int counter2 = 0; counter2 < 50; counter2++)
            {
                randInt = Random.Range(0, 15);
                if (randInt == 0)
                {
                    terrainArray[counter1, counter2] = Instantiate(tree, new Vector3(counter1, 0, counter2), Quaternion.Euler(-90, 0, 0));
                }
                else if (randInt == 1)
                {
                    terrainArray[counter1, counter2] = Instantiate(rock, new Vector3(counter1, 0, counter2), Quaternion.Euler(-90, 0, 0));
                }
                else if (randInt > 1 && randInt < 15)
                {
                    terrainArray[counter1, counter2] = Instantiate(grass, new Vector3(counter1, 0, counter2), Quaternion.Euler(-90, 0, 0));
                }
            }
        }

        //This generates the rails.
        int randPos = Random.Range(10, 40);
        for (int counter = 0; counter < 11; counter++)
        {
            Destroy(terrainArray[counter, randPos]);
            terrainArray[counter, randPos] = Instantiate(rail, new Vector3(counter, 0, randPos), Quaternion.Euler(-90, 0, 0));
            terrainArray[counter, randPos].GetComponent<SpawnTrain>().player = player;
        }

        //This generates the roads.
        int intVal = 0;
        while (intVal < 3)
        {
            int randPos2 = Random.Range(10, 40);
            if (randPos2 != randPos)
            {
                for (int counter = 0; counter < 11; counter++)
                {
                    Destroy(terrainArray[counter, randPos2]);
                    terrainArray[counter, randPos2] = Instantiate(road, new Vector3(counter, 0, randPos2), Quaternion.Euler(-90, 90, 0));
                    terrainArray[counter, randPos2].GetComponent<spawnCar>().player = player;
                }
                intVal++;
            }
        }

        //This ensures that the player stands on a grass block.
        Destroy(terrainArray[5, 1]);
        terrainArray[5, 1] = Instantiate(grass, new Vector3(5, 0, 1), Quaternion.Euler(-90, 90, 0));

        //This calls the function that generates the coins.
        Coins();

        //This sets the terrain generation to true.
        terrainBool = true;*/
    }

    public void Initial(){
        while(y < 40)
        {
            Generate();
        }
    }
    
    //This is the function that deletes the terrain.
    public void Delete()
    {
        for (int counter1 = 0; counter1 < 11; counter1++)
        {
            for (int counter2 = 0; counter2 < 50; counter2++)
            {
                Destroy(terrainArray[counter1][ counter2], 0);
                Destroy(coinArray[counter1, counter2], 0);
            }
        }

        //This sets the terrain to be not generated.
        terrainBool = false;
    }

    //This function generates the coins.
    public void Coins()
    {
        int randInt;

        for (int counter1 = 0; counter1 < 11; counter1++)
        {
            for (int counter2 = 0; counter2 < 50; counter2++)
            {
                if (terrainArray[counter1][ counter2].tag == "grass")
                {
                    randInt = Random.Range(0, 75);
                    if (randInt == 0)
                    {
                        coinArray[counter1, counter2] = Instantiate(coin, new Vector3(counter1, 1, counter2), Quaternion.Euler(0, 0, 90));
                        coinArray[counter1, counter2].GetComponent<SpinCoin>().player = player;
                        coinArray[counter1, counter2].GetComponent<SpinCoin>().coinText = coinText;
                    }
                }
            }
        }
    }

    //This function resets the player back to the beginning of the map.
    public void ResetPlayer()
    {
        transform.position = new Vector3(5, 1, 0);
    }
}