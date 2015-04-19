using UnityEngine;
using System.Collections;

public class GetPoints : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {

            //GameObject light = transform.FindChild("PointLight").gameObject;

            //GameObject xd =light.transform.FindChild("Light").gameObject;

            //xd.s
			PlayerMovement.curPoints++;
			CollectiblesUI.smallCounter++;
            Destroy(gameObject);

        }


    }

}
