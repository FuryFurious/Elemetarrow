using UnityEngine;
using System.Collections;

public class JumpReset : MonoBehaviour {

    public PlayerMovement player;

    void Start()
    {
        player = transform.parent.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D()
    {
        player.ResetJump();
    }

    void Update()
    {

    }
}
