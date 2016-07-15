using UnityEngine;
using System.Collections;

public class SunRotations : MonoBehaviour 
{
	/// <summary>
	/// The Gameobject of which the set of flares are children
	/// </summary>
	public GameObject flares;
	/// <summary>
	/// The speed at which this object (The Sun) rotates.
	/// </summary>
	public float rotationRate;
	/// <summary>
	/// The speed at which the flare objects move across the surface
	/// </summary>
	public float danceSpeed;
	/// <summary>
	/// The amount of time between changes in direction
	/// </summary>
	float switchTimer;
	/// <summary>
	/// Dictates which axes to rotate around. 0 is just X, 1 is just Y, 2 is just Z, 3 is X and Y, 4 is X and Z, 5 is Y and Z, and 6 is X, Y and Z.
	/// </summary>
	int axisSelect;	

	/// <summary>
	/// Initialise timer and axis selection
	/// </summary>
	void Start()
	{
		switchTimer = 0;
		axisSelect = 0;
	}

	void Update () 
	{
		danceSpeed /= 10;
		// Rotate this object CounterClockwise
		transform.Rotate (0, -rotationRate, 0);

		// Maintain a steady rotation rate, even if the framerate drops
		switchTimer += Time.deltaTime;

		// If it is time to change direction, randomly select a combination of axes
		if (switchTimer >= 1) 
		{
			axisSelect = Random.Range (0, 7);
			switchTimer = 0;
		}

		// Rotate the flares depending on the selected combination of axes
		else 
		{
			if (axisSelect == 0) {
				flares.transform.Rotate (danceSpeed, 0, 0);
			} else if (axisSelect == 1) {
				flares.transform.Rotate (0, danceSpeed, 0);
			} else if (axisSelect == 2) {
				flares.transform.Rotate (0, 0, danceSpeed);
			} else if (axisSelect == 3) {
				flares.transform.Rotate (danceSpeed, danceSpeed, 0);
			} else if (axisSelect == 4) {
				flares.transform.Rotate (danceSpeed, 0, danceSpeed);
			} else if (axisSelect == 5) {
				flares.transform.Rotate (0, danceSpeed, danceSpeed);
			} else if (axisSelect == 6) {
				flares.transform.Rotate (danceSpeed, danceSpeed, danceSpeed);
			}
			// In addition to that rotation, rotate the flares clockwise so they have a constant rotation as well as a random one
			flares.transform.Rotate (0, danceSpeed * 2, 0);
		}
		danceSpeed *= 10;
	}
}
