using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToScene(int id){

		if (Time.timeScale == 0)
			Time.timeScale = 1;



		Application.LoadLevel (id);

	}
}
