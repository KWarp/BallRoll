using UnityEngine;
using System;
using System.Collections;

public class BallInput : MonoBehaviour 
{
	
	public Rigidbody2D rigidBody2D;
	public float acceleration = 10f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void FixedUpdate()
	{
		pushBall();
	}


	/// <summary>
	/// Accelerate the ball based on arrow key input
	/// </summary>
	private void pushBall()
	{
		Vector2 force = Vector2.zero;

		/*
		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				Debug.Log("KeyCode down: " + kcode);
		}
        */

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			force.x -= acceleration;
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			force.x += acceleration;
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			force.y += acceleration;
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			force.y -= acceleration;
		}

		//Debug.Log ("force " + force);

		// apply force
		rigidBody2D.AddForce (force);
	}
}
