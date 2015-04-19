using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

    public float speed = 12.0f;

    public float lifeTime = 5.0f;
    private float startLifeTime;
    public Vector2 direction;

    private bool isFlying = true;
    private Rigidbody2D _rigidBody;

	// Use this for initialization
	void Start () {

        startLifeTime = lifeTime;
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

    void Update()
    {
        lifeTime -= Time.deltaTime;

        Color colorX = gameObject.GetComponent<MeshRenderer>().material.color;

        gameObject.GetComponent<MeshRenderer>().material.color = new Color(colorX.r, colorX.g, colorX.b, 255 / startLifeTime * lifeTime);

        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (!collider.CompareTag("BushCollider"))
        {
            isFlying = false;

            if (!collider.gameObject.isStatic)
            {
                collider.attachedRigidbody.AddForce(_rigidBody.velocity * 5.0f);
                gameObject.transform.parent = collider.transform;
            }

            _rigidBody.isKinematic = true;

        }
    }
}
