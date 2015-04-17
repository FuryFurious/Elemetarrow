using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

    public float speed = 12.0f;
    public Vector2 direction;

    private bool isFlying = true;
    private Rigidbody2D _rigidBody;

	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();

        _rigidBody.AddForce(direction * speed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isFlying)
        {
            float angle = Mathf.Atan2(_rigidBody.velocity.y, _rigidBody.velocity.x) * Mathf.Rad2Deg;
            _rigidBody.rotation = angle;
        }

	}

    void OnTriggerEnter2D()
    {
        isFlying = false;
        _rigidBody.isKinematic = true;
    }
}
