using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

    public float deathDepth = -5.0f;
    public float movementSpeed = 5.0f;
    public float jumpHeight = 120.0f;
    public float cooldown = 0.5f;

    public Object arrowPrefab;

    private Camera mainCamera;
    private float totalCooldown;
    private Rigidbody2D _rigidBody;
    private bool isJumping = false;

  

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
        _rigidBody = GetComponent<Rigidbody2D>();
        totalCooldown = cooldown;
        cooldown = 0.0f;

        SavePoint.currentSpawnpoint = new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0, 0));

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            _rigidBody.AddForce(new Vector2(0, jumpHeight));
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer.Equals(10)){
            isJumping = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && cooldown <= 0.0f)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCamera.transform.position.z;

            Vector3 fromTo = mainCamera.ScreenToWorldPoint(mousePos) - transform.position;
            float rotation = Mathf.Atan2(fromTo.y, fromTo.x) * Mathf.Rad2Deg;

            GameObject obj = (GameObject)Instantiate(arrowPrefab,transform.position,Quaternion.identity);
            //obj.transform.position = transform.position;
            ArrowMovement arrow = obj.GetComponent<ArrowMovement>();
            arrow.direction = new Vector2(fromTo.x, fromTo.y);
  

            cooldown = totalCooldown;
            //Debug.DrawRay(transform.position ,fromTo, Color.red, 1.0f);
        }

        if(cooldown > 0.0f)
            cooldown -= Time.deltaTime;


     
        if (transform.position.y <= deathDepth)
        {
          //  Debug.Log(transform.position.y);

            transform.position = new Vector3(SavePoint.currentSpawnpoint.x, SavePoint.currentSpawnpoint.y, 0);
        }
    }
}
