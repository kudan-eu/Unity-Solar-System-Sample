using UnityEngine;
using System.Collections;

public class CloudRotation : MonoBehaviour 
{
	/// <summary>
	/// The "planet" object that this object is attached to.
	/// </summary>
	public Orbit planet;

	// Update is called once per frame
	void Update () 
	{
		// Rotate the clouds clockwise
		transform.Rotate (0, planet.rotationRate / 10, 0);
	}
}
