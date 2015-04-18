using UnityEngine;
using System.Collections;

public class PressButton : MonoBehaviour {


    public FlipSwitch switchScript;

    public Vector3 pressDir;

    Vector3 resetPosition;

    GameObject obj;



	// Use this for initialization
	void Start () {

        obj = gameObject.transform.FindChild("Spawner").gameObject;
        obj.GetComponent<ParticleSystem>().enableEmission = false;

        resetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //if (!coll)
        //    transform.position = resetPosition;
        //else
        //{
        //    coll = false;
        //}
	}


    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("FireArrow") || collider.CompareTag("NormalArrow"))
        {
            transform.position = resetPosition;
            obj.GetComponent<ParticleSystem>().enableEmission = false;

        }





    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("FireArrow") || collider.CompareTag("NormalArrow"))
        {
            transform.position = resetPosition - pressDir;

            obj.GetComponent<ParticleSystem>().enableEmission = true;


        }

        
        


    }

    void OnTriggerEnter2D(Collider2D collider)
    {

       

        if (collider.CompareTag("Player") || collider.CompareTag("FireArrow") || collider.CompareTag("NormalArrow"))
        {
            switchScript.flipSwitch(true);
        }

    }


}
