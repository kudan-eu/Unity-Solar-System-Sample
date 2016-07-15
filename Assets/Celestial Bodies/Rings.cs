using UnityEngine;
using System.Collections;

public class Rings : MonoBehaviour 
{
	/// <summary>
	/// The "planet" object that this "rings" object is associated with.
	/// </summary>
	public GameObject Planet;

	void LateUpdate () 
	{
		transform.position = Planet.transform.position;
	}
}
