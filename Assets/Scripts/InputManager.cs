using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerBehaviour player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // PAUSE
        InputPause();
        // JUMP
        InputJump();
        // RUN
        InputRun();
        // AXIS
        InputMovement();
    }

    void InputPause()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("PAUSE!!!!!");
        }
    }

    void InputJump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("JUMP!!!!");
            //player.Jump();
        }
    }

    void InputRun()
    {
        if(Input.GetButtonDown("Run"))
        {
            Debug.Log("RUN!!!!!");
            //player.Run();
        }
    }

    void InputMovement()
    {
        Vector2 axis = Vector2.zero;
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
        //player.SetAxis();
    }
}
