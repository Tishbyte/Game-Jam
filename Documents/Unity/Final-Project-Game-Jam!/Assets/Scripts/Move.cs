using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class Move : MonoBehaviour {

    //This activates the controller tracking.
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

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
            //This resets the position.
            player.transform.position = new Vector3(5, 1, 0);

            //This deletes and regenerates the terrain.
            player.GetComponent<GenerateTerrain>().Delete();
            player.GetComponent<GenerateTerrain>().Generate();
        }

        //This checks if the user presses the touchpad.
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //This gets the 2D position.
            Vector2 touchpad = (device.GetAxis(EVRButtonId.k_EButton_Axis0));
            //print("Pressing Touchpad");

            //This checks where the user presses and moves them accordingly.
            if (touchpad.y > 0.6f && player.transform.position.z != 50)
            {
                if (GenerateTerrain.terrainArray[(int)player.transform.position.x, (int)player.transform.position.z + 1].tag == "grass")
                {
                    player.transform.position = new Vector3(player.transform.position.x, 1, player.transform.position.z + 1);
                    //print("Moving Up");
                }
                
            }

            else if (touchpad.y < -0.6f && player.transform.position.z != 0)
            {
                if (GenerateTerrain.terrainArray[(int)player.transform.position.x, (int)player.transform.position.z - 1].tag == "grass")
                {
                    player.transform.position = new Vector3(player.transform.position.x, 1, player.transform.position.z - 1);
                    //print("Moving Down");
                }
                
            }

            if (touchpad.x > 0.6f && player.transform.position.x != 11)
            {
                if (GenerateTerrain.terrainArray[(int)player.transform.position.x + 1, (int)player.transform.position.z].tag == "grass")
                {
                    player.transform.position = new Vector3(player.transform.position.x + 1, 1, player.transform.position.z);
                    //print("Moving Right");
                }
                

            }

            else if (touchpad.x < -0.6f && player.transform.position.x != 0)
            {
                if (GenerateTerrain.terrainArray[(int)player.transform.position.x - 1, (int)player.transform.position.z].tag == "grass")
                {
                    player.transform.position = new Vector3(player.transform.position.x - 1, 1, player.transform.position.z);
                    //print("Moving left");
                }
                
            }

        }
    }
}