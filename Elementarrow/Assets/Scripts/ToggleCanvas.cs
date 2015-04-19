using UnityEngine;
using System.Collections;

public class ToggleCanvas : MonoBehaviour {

	public Canvas canvas1;
	public Canvas canvas2;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggle(){
		canvas1.enabled = !canvas1.enabled;
		canvas2.enabled = !canvas2.enabled;

	}
}
