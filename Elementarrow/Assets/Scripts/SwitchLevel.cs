using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

    public string levelSwitchName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<LevelHandler>().changeLevel(levelSwitchName);
        }

    }
}
