using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject generate, menu, best;

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
            generate.GetComponent<GenerateTerrain>().Initial(840);
            Move.lowestZ = 0;
            Move.farthestZ = 0;
            generate.transform.position = new Vector3(10, 1, 0);
            menu.gameObject.active = false;
            gameObject.active = false;
        }
    }
}