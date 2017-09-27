using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Best : MonoBehaviour {

    public static int best = 0;

    public static void newBest(int num)
    {
        if (num > best)
        {
            best = num;
        }
    }
    public void moveBest()
    {
        transform.position = new Vector3(10, 10, best);
    }
}
