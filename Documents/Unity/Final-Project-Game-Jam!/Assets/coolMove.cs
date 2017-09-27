using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolMove : MonoBehaviour {

    public string type;
    private bool direction = true;
    public float cloudSpeed;
    private int counter = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(movement());
    }

    public IEnumerator movement()
    {
        if (type == "cloud")
        {
            while (true)
            {
                if (direction == true)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * cloudSpeed);
                    transform.Translate(Vector3.up * Time.deltaTime * cloudSpeed);
                    gameObject.transform.localScale += new Vector3(.005f, .005f, .005f) * Time.deltaTime * cloudSpeed;
                }
                else if (direction == false)
                {
                    transform.Translate(Vector3.back * Time.deltaTime * cloudSpeed);
                    transform.Translate(Vector3.down * Time.deltaTime * cloudSpeed);
                    gameObject.transform.localScale += new Vector3(-.005f, -.005f, -.005f) * Time.deltaTime * cloudSpeed;
                }

                counter++;
                if (counter >= 100)
                {
                    direction = !direction;
                    counter = 0;
                }
                yield return new WaitForSeconds(.1f);
            }
        }
        else
        {
            while (true)
            {
                if (direction == true)
                {
                    transform.Rotate(Vector3.forward * Time.deltaTime * 80);
                    transform.Translate(Vector3.forward * Time.deltaTime * cloudSpeed);
                }
                else if (direction == false)
                {
                    transform.Rotate(Vector3.back * Time.deltaTime * 80);
                    transform.Translate(Vector3.back * Time.deltaTime * cloudSpeed);
                }

                counter++;
                if (counter >= 200)
                {
                    direction = !direction;
                    counter = 0;
                }
                yield return new WaitForSeconds(.05f);
            }
        }
    }
}
