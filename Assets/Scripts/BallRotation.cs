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
	/// Rotate the 3D mesh with quaternions!
	/// </summary>
	private void rotateBall()
	{
		if (radius == 0) 
		{
			// can't rotate ball
			return; 
		}

		// distance the ball traveled between the last Update and this one
		// we subtract the vectors in this order to use it as a direction vector later
		Vector3 currentToLast = lastPosition - transform.position; 

		// segment length that the ball rolled along its surface
		float segment = currentToLast.magnitude;

		if (segment == 0) 
		{
			// no distance travelled, nothing to do
			return;
		}

		// to build a Quaternion to hold the desired rotation, 
		// we need a Vector3 "axis" and an angle "theta"
		// first, the axis:

		// define the down direction vector for the ball
		// the ball rolls in the x and y directions,
		// and positive z points to the ground
		// Important: 	this is DIFFERENT from Vector3.down because Vector3 assumes 
		//				a 3D world space where negative y is down
		Vector3 ballDown = new Vector3(0, 0, 1); 
		
		// use Cross Product to find the axis of rotation 
		// https://www.mathsisfun.com/algebra/vectors-cross-product.html
		Vector3 axis = Vector3.Cross(ballDown, currentToLast);

		// Cross Product will fail if both vectors are parallel or perpendicular
		if (axis == Vector3.zero) 
		{
			// this should never happen because currentToLast.z is always 0
			// but who knows where this code will be copy-pasted to...
			return;
		}

		// next, the angle theta:

		// arc length formula
		// s = r * theta
		// theta = s / r
		// http://www.mathopenref.com/arclength.html
		float theta = segment / radius; // in radians
		float thetaDegrees = theta * 180 / Mathf.PI;

		// create the rotation Quaternion
		Quaternion q = Quaternion.AngleAxis(thetaDegrees, axis);

		// apply rotation to the transform
		// q must come first in multiplication order!!!
		// Quaternion multiplication is Non-Commutative!
		transform.rotation = q * transform.rotation;
	}

}
