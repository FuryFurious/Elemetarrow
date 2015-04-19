using UnityEngine;
using System.Collections;

public class Exchange : MonoBehaviour {

    private GameObject particleSystem;
    GameObject player;
    Vector3 position;
    bool exchangeble = false;

	// Use this for initialization
	void Start () {
        particleSystem = transform.FindChild("ParticleStart").gameObject;
        player = GameObject.Find("Player");
        position = player.transform.position;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        if (col.gameObject.name == "ArrowAerial(Clone)")
        {
            Destroy(col.gameObject);
            particleSystem.SetActive(true);
            exchangeble = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () 
    {
        position = player.transform.position;
        if (Input.GetMouseButtonDown(1) && exchangeble == true)
        {
            player.transform.position = transform.position;
            transform.position = position;
            Debug.Log("change positions");
            exchangeble = false;
            particleSystem.SetActive(false);
        }
    }
}
