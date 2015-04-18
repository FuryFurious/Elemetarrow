using UnityEngine;
using System.Collections;

public class EntityFollower : MonoBehaviour {

    public Transform targetTransform;
    public float moveSpeed = 1.0f;

	// Update is called once per frame
	void Update () 
    {
        Vector2 cameraPos = new Vector2(transform.position.x, transform.position.y - 2.0f);
        Vector2 targetPos = new Vector2(targetTransform.position.x, targetTransform.position.y);

        transform.Translate((targetPos - cameraPos) * Time.deltaTime * moveSpeed);
    }
}
