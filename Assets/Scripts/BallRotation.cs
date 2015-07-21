using UnityEngine;
using System.Collections;

public class BallRotation : MonoBehaviour 
{

	public float radius = 0.5f;

	private Vector3 lastPosition;


	// Use this for initialization
	void Start () 
	{
		lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void FixedUpdate()
	{
		rotateBall();

		lastPosition = transform.position;
	}



	/// <summary>
	/// Rotate the 3d mesh with quaternions!
	/// </summary>
	private void rotateBall()
	{
		// calculate rotation based on the positional movement of the ball
		// between the last frame and this one
		Vector3 currentPosition = transform.position;
		Vector3 currentBottom = new Vector3 (
			currentPosition.x, 
			currentPosition.y, 
			currentPosition.z + radius); // the bottom of the ball this update
		Vector3 lastBottom = new Vector3 (
			lastPosition.x, 
			lastPosition.y, 
			lastPosition.z + radius); // the bottom of the ball last update

		// direction Vectors that appriximate how much the ball rotated
		// "good enough" for small movements between frames
		Vector3 ballDown = currentBottom - currentPosition;
		Vector3 ballRotated = lastBottom - currentPosition;

		// store the rotation change in a Quaternion
		Quaternion q = Quaternion.FromToRotation(ballDown, ballRotated); // that was easy!

		// apply rotation to the transform
		Quaternion newRotation = q * transform.rotation; // q must come first in multiplication order!!!
		transform.rotation = newRotation;


	}

}
