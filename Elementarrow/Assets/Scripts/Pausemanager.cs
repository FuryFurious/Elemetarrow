using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Pausemanager : MonoBehaviour {
	
	Canvas canvas;
	
	void Start()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	
	void Update()
	{


	}
	
	public void Pause()
	{
		canvas.enabled = !canvas.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}
	
	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}