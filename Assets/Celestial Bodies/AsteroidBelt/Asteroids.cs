using UnityEngine;
using System.Collections;

public class Asteroids : MonoBehaviour 
{
	/// <summary>
	/// The speed at which this object rotates
	/// </summary>
	public float rotationRate;

	void Update()
	{
		// Rotate the asteroid belt without altering its position, ensuring that it rotates relative to its own Y vector rather than the World Y vector
		transform.Rotate (new Vector3 (0, 0, rotationRate / 10), Space.Self);
	}
}