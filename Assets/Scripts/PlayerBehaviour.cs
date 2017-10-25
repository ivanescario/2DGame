using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collisions))]
public class PlayerBehaviour : MonoBehaviour
{
    public enum State { Default, Dead, God }
    public State state;

    [Header("State")]
    public bool canMove = true;
    public bool canJump = true;
    public bool running = false;
    public bool isFacingRight = true;
    public bool isJumping = false;
    [Header("Physics")]
    public Rigidbody2D rb;
    public Collisions2 collisions;
    [Header("Speed Properties")]
    public float walkSpeed = 3;
    public float runSpeed = 2;
    public float movementSpeed;
    [Header("Force Properties")]
    public float jumpWalkForce;
    public float jumpRunForce;
    public float jumpForce;
    [Header("Movement")]
    public Vector2 axis;

    // Use this for initialization
    void Start ()
    {
        collisions = GetComponent<Collisions2>();

        collisions.MyStart();
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch(state)
        {

        }
		
	}

    void DefaultUpdate()
    {

    }

    private void FixedUpdate()
    {

    }

   public void SetAxis(Vector2 inputAxis)
    {

    }
}
