using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace Kudan.AR
{
	public class TouchControl : MonoBehaviour 
	{
		public KudanTracker _kudanTracker;
		public TrackingMethodMarkerless _markerlessTracking;

		#if UNITY_ANDROID || UNITY_IOS
		float zoomSpeed;	// The rate at which the pinch control scales the object
		float moveSpeed;	// The rate at which the swipe control rotates the object

		void Update()
		{
			for (int i = 0; i < Input.touches.Length; i++) {
				if (Input.touches[i].phase == TouchPhase.Ended) {
					processTap ();
				}
			}
		}
		void processTap()
		{
			
			if (!_kudanTracker.ArbiTrackIsTracking ()) {
				// from the floor placer.
				Vector3 floorPosition;			// The current position in 3D space of the floor
				Quaternion floorOrientation;	// The current orientation of the floor in 3D space, relative to the device

				_kudanTracker.FloorPlaceGetPose (out floorPosition, out floorOrientation);	// Gets the position and orientation of the floor and assigns the referenced Vector3 and Quaternion those values
				_kudanTracker.ArbiTrackStart (floorPosition, floorOrientation);				// Starts markerless tracking based upon the given floor position and orientations
			} else {
				_kudanTracker.ArbiTrackStop ();

			}

		}
		#endif
	}
}