using UnityEngine;
using System.Collections;

public class FlipSwitch : MonoBehaviour {


    bool startFlipping;

    public int flipSpeed = 200;
    bool leftFlip;
    bool rightFlip;


    float degree = 0;

	// Use this for initialization
	void Start () {
        startFlipping = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (startFlipping)
        {
            if (degree < 180)
            {

                degree += Time.deltaTime * flipSpeed;

                if ((degree > 180))
                {
                    degree -= Time.deltaTime * flipSpeed;
                    transform.Rotate(new Vector3(0, 0, 1), 180 - (degree));

                    startFlipping = false;
                    degree = 0;

                }
                else
                    transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * flipSpeed);
            }

        }

	}

    public void flipSwitch(bool right)
    {
        startFlipping = true;

        if (rightFlip)
        {
            this.rightFlip = true;
            this.leftFlip = false;
        }
        else
        {
            this.rightFlip = false;
            this.leftFlip = true;

        }
    }
}
