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

		// direction Vectors
		Vector3 ballDown = currentBottom - currentPosition;
		Vector3 ballRotated = lastBottom - currentPosition;

/*
		// faster (but less accurate) rotation approximation
		// store the rotation change in a Quaternion
		Quaternion qSimple = Quaternion.FromToRotation(ballDown, ballRotated);
		
		// apply rotation to the transform
		// qSimple must come first in multiplication order!!!
		transform.rotation = qSimple * transform.rotation;
		return;
*/

		// segment length that the ball rotated
		Vector3 distance = currentBottom - lastBottom;
		float segment = distance.magnitude;

		if (segment == 0 || radius == 0) 
		{
			// nothing to do
			return;
		}

		// to build a Quaternion to hold the desired rotation, 
		// we need a Vector3 "axis" and an angle "theta"

		// arc length formula
		// s = r * theta
		// theta = s / r
		// http://www.mathopenref.com/arclength.html
		float theta = segment / radius; // in radians
		float thetaDegrees = theta * 180 / Mathf.PI;


		// use Cross Product to find an axis of rotation 
		Vector3 axis = Vector3.Cross(ballDown, ballRotated);

		// the axis and angle is enough to make a rotation Quaternion!
		Quaternion q = Quaternion.AngleAxis(thetaDegrees, axis);

		// apply rotation to the transform
		// q must come first in multiplication order!!!
		transform.rotation = q * transform.rotation;
	}

}
