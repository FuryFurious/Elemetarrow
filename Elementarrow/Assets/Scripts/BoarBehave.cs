using UnityEngine;
using System.Collections;

public class BoarBehave : MonoBehaviour 
{
    private static int LEFT = 0;
    private static int RIGHT = 1;

    public float    runSpeed        = 2.5f;
    public float    aggroDistance   = 5.0f;
    public int      hitPoints       = 2;

    private Animator animator;
    private Transform playerTransform;

    private int direction = RIGHT;

    private float moveMultiplier = 1.0f;
    private bool running = false;


	// Use this for initialization
	void Start () {
        playerTransform = GameObject.Find("Player").transform;
        animator = transform.FindChild("boar_enemy").GetComponent<Animator>();

	}
	

    void FixedUpdate()
    {
        float toPlayerX = playerTransform.position.x - transform.position.x;
        float len = Mathf.Abs(toPlayerX);


        if (len <= aggroDistance && !running)
            running = true;

        if (running)
        {
            if (toPlayerX < 0.0f && direction == RIGHT)
            {
                direction = LEFT;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                moveMultiplier = -1.0f;
            }

            else if (toPlayerX > 0.0f && direction == LEFT)
            {
                direction = RIGHT;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                moveMultiplier = 1.0f;
            }

            transform.Translate(new Vector3((toPlayerX / len) * Time.deltaTime * runSpeed * moveMultiplier, 0, 0));
        }
            

        animator.SetBool("Run", running);
    }
}
