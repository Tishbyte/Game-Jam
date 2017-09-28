using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject generate, reset, best;
    public AudioClip menuMusic;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Controller (left)" || other.GetComponent<Collider>().name == "Controller (right)")
        {
            if (Move.lost == true)
            {
                Move.lost = false;
            }

            best.GetComponent<Best>().moveBest();
            generate.GetComponent<GenerateTerrain>().Delete();
            generate.GetComponent<AudioSource>().clip = menuMusic;
            generate.GetComponent<GenerateTerrain>().playMusic();
            Move.lowestZ = 0;
            Move.farthestZ = 0;
            generate.transform.position = new Vector3(5, 25, 0);
            /*RenderSettings.fogColor = Color.white;
            RenderSettings.fog = true;*/
            reset.gameObject.active = false;
            gameObject.active = false;
        }
    }
}
