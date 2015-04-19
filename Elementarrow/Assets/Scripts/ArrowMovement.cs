using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

    public float speed = 12.0f;

    public float lifeTime = 5.0f;
    private float startLifeTime;
    public Vector2 direction;

    private bool isFlying = true;
    private Rigidbody2D _rigidBody;
    private MeshRenderer renderer;
    private ParticleSystem particleSystem;

	// Use this for initialization
    void Start()
    {

        startLifeTime = lifeTime;
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(direction * speed);

        renderer = gameObject.transform.FindChild("arrow").gameObject.GetComponent<MeshRenderer>();

        if (name.Equals("ArrowFire(Clone)"))
        {
            particleSystem = transform.FindChild("FireMobile").GetComponent<ParticleSystem>();
        }

        else if (name.Equals("ArrowAerial(Clone)"))
        {
            particleSystem = transform.FindChild("Particle System").GetComponent<ParticleSystem>();
        }

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

        float startFade = 0.2f;
        float t = (lifeTime / startLifeTime);

        if (t <= startFade)
        {
            t /= startFade;

            Color colorX = renderer.material.color;
            renderer.material.color = new Color(colorX.r, colorX.g, colorX.b, t);


            if (particleSystem != null)
            {
                particleSystem.enableEmission = false;
            }
        }


        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        ArrowTarget target = collider.GetComponent<ArrowTarget>();

        BoarBehave behave = collider.gameObject.GetComponent<BoarBehave>();


        if (target != null)
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

        if (behave != null && !_rigidBody.isKinematic)
        {
            behave.hitPoints--;

            if (behave.hitPoints <= 0)
                Destroy(behave.gameObject);
        }
    }
}
