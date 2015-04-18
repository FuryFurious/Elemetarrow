using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeButton : MonoBehaviour {

	public Button button;
	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
		if (PlayerMovement.curSkill == 0){
			button.image.sprite = sp1;
		}
		if (PlayerMovement.curSkill == 1){
			button.image.sprite=sp2;
		}
		if (PlayerMovement.curSkill == 2){
			button.image.sprite=sp3;
		}

	}
}
