using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

    public float deathDepth = -5.0f;
    public float movementSpeed = 5.0f;
    public float jumpHeight = 120.0f;
    public float cooldown = 0.5f;

    private float minArrowSpeed = 2.0f;
    private float maxArrowSpeed = 10.0f;

    public Object arrowPrefab;
	public Object normalArrow;
	public Object fireArrow;
	public Object airArrow;

    public Transform arrowStartTransform;

    public Animator bowAnimator;

    private Camera mainCamera;
    private float totalCooldown;
    private Rigidbody2D _rigidBody;
    private bool isJumping = false;
	private Pausemanager pausemanager;
	private  int maxSkill = 3;

    private Animator animator;
    private GameObject mesh;
    private Vector3 mousePos;
	private LookDirection direction = LookDirection.Right;

	public static bool paused;
	public static int curSkill;

	enum LookDirection {Left, Right };

	// Use this for initialization
    void Start()
    {
        mesh = transform.FindChild("satyr").gameObject;
        animator = transform.FindChild("satyr").GetComponent<Animator>();

        mainCamera = Camera.main;
        _rigidBody = GetComponent<Rigidbody2D>();
        totalCooldown = cooldown;
        cooldown = 0.0f;
		pausemanager = FindObjectOfType (typeof(Pausemanager)) as Pausemanager;
		paused = false;
		curSkill = 0;


        SavePoint.currentSpawnpoint = new Vector2(transform.position.x, transform.position.y);

    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {

        float horz = Input.GetAxis("Horizontal");

        if (horz != 0.0f)
        {
            if (direction == LookDirection.Right)
            {

                if (horz > 0.0f)
                {
                    if (!animator.GetBool("RunForward"))
                        animator.SetBool("RunForward", true);

                    transform.Translate(horz * Time.deltaTime * movementSpeed, 0, 0);
                }

                else
                {
                    if (horz < 0.0f)
                    {
                        if (!animator.GetBool("RunBack"))
                            animator.SetBool("RunBack", true);

                        transform.Translate(horz * Time.deltaTime * movementSpeed, 0, 0);
                    }
                }
            }

            else if (direction == LookDirection.Left)
            {

                if (horz > 0.0f)
                {
                    if (!animator.GetBool("RunBack"))
                        animator.SetBool("RunBack", true);

                    transform.Translate(horz * Time.deltaTime * movementSpeed, 0, 0);
                }

                else
                {
                    if (horz < 0.0f)
                    {
                        if (!animator.GetBool("RunForward"))
                            animator.SetBool("RunForward", true);

                        transform.Translate(horz * Time.deltaTime * movementSpeed, 0, 0);
                    }
                }
            }
        }

        else
        {
            animator.SetBool("RunForward", false);
            animator.SetBool("RunBack", false);
        }



        

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            animator.SetTrigger("Jump");
            _rigidBody.AddForce(new Vector2(0, jumpHeight));
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer.Equals(10)){
            animator.SetTrigger("Land");
            isJumping = false;

        }
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            

		if (Input.GetButtonDown("Pause")){
			cooldown = 0.2f;
			pausemanager.Pause ();
		}

        

		if (Input.GetAxis ("MouseScrollWheelDown") > 0.9) {
			curSkill = (curSkill - 1);

			if (curSkill < 0) {
				curSkill = maxSkill - 1;
			}

		}
		if (Input.GetAxis ("MouseScrollWheelUp") > 0.9) {
			curSkill = (curSkill+1)% maxSkill;
		}

		if (curSkill == 0)
			arrowPrefab = normalArrow;
		
		if (curSkill == 1)
			arrowPrefab = fireArrow;
		
		if (curSkill == 2)
			arrowPrefab = airArrow;






			if (Input.GetButtonDown ("Fire1") && cooldown <= 0.0f) {
				animator.SetTrigger ("Shoot");
			bowAnimator.SetTrigger("Shoot");
			}

					


		






			if (mousePos.x < transform.position.x && direction == LookDirection.Right) {
				direction = LookDirection.Left;
				mesh.transform.rotation = Quaternion.Euler (0.0f, 270.0f, 0.0f);
			} else if (mousePos.x > transform.position.x && direction == LookDirection.Left) {
				direction = LookDirection.Right;
				mesh.transform.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
			}



			if (cooldown > 0.0f)
				cooldown -= Time.deltaTime;


     
			if (transform.position.y <= deathDepth) {
				//  Debug.Log(transform.position.y);

				transform.position = new Vector3 (SavePoint.currentSpawnpoint.x, SavePoint.currentSpawnpoint.y, 0);
			}

    }

    public void CreateShootArrow()
    {
        if (cooldown <= 0.0f)
        {
            Debug.Log("Shot");

            Vector3 fromTo = mousePos - transform.position;
            float length = new Vector2(fromTo.x, fromTo.y).magnitude;
            float rotation = Mathf.Atan2(fromTo.y, fromTo.x) * Mathf.Rad2Deg;

            GameObject obj = (GameObject)Instantiate(arrowPrefab, new Vector3(arrowStartTransform.position.x, arrowStartTransform.position.y, 0.0f), Quaternion.identity);
            //obj.transform.position = transform.position;
            ArrowMovement arrow = obj.GetComponent<ArrowMovement>();

            float speed = Mathf.Clamp(length, minArrowSpeed, maxArrowSpeed);

            arrow.direction = new Vector2(fromTo.x / length, fromTo.y / length) * speed;

            cooldown = totalCooldown;
            //Debug.DrawRay(transform.position ,fromTo, Color.red, 1.0f);
        }
    }
}
