using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class Move : MonoBehaviour {

    //This activates the controller tracking.
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    public GameObject reset, menu;

    public static int lowestZ = 0;
    public static int farthestZ = 0;
    public static bool lost = false;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }
    public GameObject player;

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }
    // Update is called once per frame
    void Update () {

        //This checks if the user clicks the reset button.
        if (SteamVR_Controller.Input((int)trackedObj.index).GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if (reset.activeInHierarchy == false && player.transform.position != new Vector3(5, 25, 0))
            {
                reset.active = true;
                menu.active = true;
            }
            else if(reset.activeInHierarchy == true && player.transform.position != new Vector3(0, 15, 0))
            {
                reset.active = false;
                menu.active = false;
            }
        }

        //This checks if the user presses the touchpad.
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && lost == false)
        {
            //This gets the 2D position.
            Vector2 touchpad = (device.GetAxis(EVRButtonId.k_EButton_Axis0));
            //print("Pressing Touchpad");

            //This checks where the user presses and moves them accordingly.
            if (touchpad.y > 0.6f && player.transform.position.z != GenerateTerrain.z)
            {
                if (GenerateTerrain.terrainArray[(int)player.transform.position.x] [(int)player.transform.position.z + 1].tag == "grass")
                {
                    player.transform.position = new Vector3(player.transform.position.x, 1, player.transform.position.z + 1);
                    //print("Moving Up");

                    if (player.transform.position.z > farthestZ-1)
                    {
                        farthestZ = (int)player.transform.position.z;
                        for (int counter1 = 0; counter1 < 21; counter1++)
                        {
                            GenerateTerrain.terrainArray[counter1].Add(null);
                            GenerateTerrain.coinArray[counter1].Add(null);
                        }
                        player.GetComponent<GenerateTerrain>().Initial(21);
                        if (farthestZ > 10)
                        {
                            for (int counter = 0; counter < 21; counter++)
                            {
                                Destroy(GenerateTerrain.terrainArray[counter][lowestZ], 0);
                                GenerateTerrain.terrainArray[counter][lowestZ] = null;
                                if (GenerateTerrain.coinArray[counter][lowestZ] != null)
                                {
                                    Destroy(GenerateTerrain.coinArray[counter][lowestZ], 0);
                                }
                            }
                            lowestZ++;
                        }
                    }
                }
                
            }

            else if (touchpad.y < -0.6f && player.transform.position.z != lowestZ)
            {
                if (GenerateTerrain.terrainArray[(int)player.transform.position.x][ (int)player.transform.position.z - 1].tag == "grass")
                {
                    player.transform.position = new Vector3(player.transform.position.x, 1, player.transform.position.z - 1);
                    //print("Moving Down");
                }
                
            }

            if (touchpad.x > 0.6f && player.transform.position.x != 20)
            {
                if (GenerateTerrain.terrainArray[(int)player.transform.position.x + 1][ (int)player.transform.position.z].tag == "grass")
                {
                    player.transform.position = new Vector3(player.transform.position.x + 1, 1, player.transform.position.z);
                    //print("Moving Right");
                }
                

            }

            else if (touchpad.x < -0.6f && player.transform.position.x != 0)
            {
                if (GenerateTerrain.terrainArray[(int)player.transform.position.x - 1][ (int)player.transform.position.z].tag == "grass")
                {
                    player.transform.position = new Vector3(player.transform.position.x - 1, 1, player.transform.position.z);
                    //print("Moving left");
                }
                
            }

        }
    }
}