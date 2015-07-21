using UnityEngine;
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
		
		// apply force
		rigidBody2D.AddForce (force);
	}
}
