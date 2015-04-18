using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 5.0f;
    public float jumpSpeed = 12.0f;

    public Object arrowPrefab;

    private Camera mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * jumpSpeed, 0) * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCamera.transform.position.z;

            Vector3 fromTo = mainCamera.ScreenToWorldPoint(mousePos) - transform.position;
            float rotation = Mathf.Atan2(fromTo.y, fromTo.x) * Mathf.Rad2Deg;

            GameObject obj = (GameObject)Instantiate(arrowPrefab,transform.position,Quaternion.identity);
            //obj.transform.position = transform.position;
            ArrowMovement arrow = obj.GetComponent<ArrowMovement>();
            arrow.direction = new Vector2(fromTo.x, fromTo.y);
  
            //Debug.DrawRay(transform.position ,fromTo, Color.red, 1.0f);
        }
    }
}
