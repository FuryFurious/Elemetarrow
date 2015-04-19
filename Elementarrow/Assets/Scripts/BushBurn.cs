using UnityEngine;
using System.Collections;

public class BushBurn : MonoBehaviour {

    GameObject fire;
    Transform thisObj;

    bool burned;

    public float burnedTime;
    float runBurnTime;

	// Use this for initialization
	void Start () {


       // gameObject.GetComponent<Transform>().localScale = new Vector3(0.001f, 0.0001f, 0.0001f);

        

        fire = gameObject.transform.FindChild("FireMobile").gameObject;
        fire.GetComponent<ParticleSystem>().enableEmission = false;
        runBurnTime = burnedTime;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (burned)
        {
            runBurnTime -= Time.deltaTime;

            gameObject.GetComponent<MeshRenderer>().material.color -= new Color(0, 0, 0, Time.deltaTime/5);

            if (gameObject.GetComponent<MeshRenderer>().material.color.a <= 0.35f)
                fire.GetComponent<ParticleSystem>().enableEmission = false;

            if (gameObject.GetComponent<MeshRenderer>().material.color.a <= 0.1)
                Destroy(gameObject);
        }


	}


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("FireArrow") && collider.isTrigger)
        {

            burned = true;
            fire.GetComponent<ParticleSystem>().enableEmission = true;
            
        }

        
    }
}
