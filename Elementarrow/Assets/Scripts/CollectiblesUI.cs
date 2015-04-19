using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollectiblesUI : MonoBehaviour {

	public Button C1;
	public Button C2;
	public Button C3;
	public Button C4;
	public Button C5;

	private List<Button> Collectibles;

	public Sprite CG1;
	public Sprite CG2;
	public Sprite CG3;
	public Sprite CG4;

	public static int smallCounter;
	private int bigCouner;

	private Button curC;

	// Use this for initialization
	void Start () {

		smallCounter = 0;
		bigCouner = 0;

		Collectibles = new List<Button> ();
		Collectibles.Add (C1);
		Collectibles.Add (C2);
		Collectibles.Add (C3);
		Collectibles.Add (C4);
		Collectibles.Add (C5);

		curC = Collectibles [0];
	
	}
	
	// Update is called once per frame
	void Update () {

		if (smallCounter == 1)
			curC.image.sprite = CG1;

		if (smallCounter == 2)
			curC.image.sprite = CG2;

		if (smallCounter == 3)
			curC.image.sprite = CG3;

		if (smallCounter == 4) {

			curC.image.sprite = CG4;
			smallCounter = 0;
			bigCouner++;
			if (bigCouner <= 4)
				curC = Collectibles[bigCouner];
		}
	
	}
}
