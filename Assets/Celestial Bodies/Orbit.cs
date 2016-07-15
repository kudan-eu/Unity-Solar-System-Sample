using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour 
{
	/// <summary>
	/// The object that this object will orbit around
	/// </summary>
	public GameObject orbitAround;

	/// <summary>
	/// The speed at which this object orbits.
	/// </summary>
	public float orbitSpeed;
	/// <summary>
	/// The speed at which this object rotates.
	/// </summary>
	public float rotationRate;

	/// <summary>
	/// The distance between this object and the object it orbits.
	/// </summary>
	public float radius;

	/// <summary>
	/// The current angle of this object relative to Unity's virtual "North"
	/// </summary>
	float angle;

	void Start()
	{
		// Randomise the starting point of each planet
		angle = Random.Range (0, 360);
	}
		
	void Update () 
	{
		// The origin of the circle should be the centre of the object around which this object orbits
		float originX = orbitAround.transform.localPosition.x;
		float originY = orbitAround.transform.localPosition.z;

		// The X and Y coordinates of this object in a 2D space, calculated using the polar coordinates (Radius and Angle) of this object
		float circleX = (originX + (radius * Mathf.Cos (angle)));
		float circleY = (originY + (radius * Mathf.Sin (angle)));

		// Update this object to its new position and rotation
		transform.localPosition = new Vector3 (circleX, orbitAround.transform.localPosition.y, circleY);
		transform.Rotate (new Vector3 (0, -rotationRate, 0));

		// Increase the angle according to the given Orbit Speed
		angle += (orbitSpeed * Time.deltaTime) / 10;
	}
}
