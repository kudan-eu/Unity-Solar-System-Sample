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
		float roughDiff;	// The amount that the finger can move on the screen before it is consider to not be tapping

		Vector2 startPos;	// The position in screen coordinates (X,Y) that the finger started touching the screen
		Vector2 endPos;		// The position in screen coordinates (X,Y) that the finger stopped touching the screen

		void Start()
		{
			//zoomSpeed = 0.5f;
			//moveSpeed = 2f;
			roughDiff = 3f;

			startPos = new Vector2 (0, 0);
			endPos = new Vector2 (0, 0);
		}

		void Update()
		{
			//processPinch();
			//processDrag ();
			processTap ();
		}

		/*void processPinch ()
		{
			if (Input.touchCount == 2)
			{
				//Store inputs
				Touch fing1 = Input.GetTouch (0);
				Touch fing2 = Input.GetTouch (1);

				if (fing1.phase == TouchPhase.Moved || fing2.phase == TouchPhase.Moved)	//If either finger has moved since the last frame
				{
					//Get previous positions
					Vector2 fing1Prev = fing1.position - fing1.deltaPosition;
					Vector2 fing2Prev = fing2.position - fing2.deltaPosition;

					//Find vector magnitude between touches in each frame
					float prevTouchDeltaMag = (fing1Prev - fing2Prev).magnitude;		
					float touchDeltaMag = (fing1.position - fing2.position).magnitude;

					//Find difference in distances
					float deltaDistance = prevTouchDeltaMag - touchDeltaMag;

					//Create appropriate vector
					float scaleChange = ((this.transform.localScale.x - deltaDistance) * zoomSpeed);

					//Scale object
					this.transform.localScale = new Vector3 (scaleChange, scaleChange, scaleChange);
				}
			}
		}*/

		/*void processDrag()
		{
			if (Input.touchCount == 1) 
			{
				//Store input
				Touch fing = Input.GetTouch (0);

				if(fing.phase == TouchPhase.Moved)	//If the finger has moved since the last frame
				{
					//Find the amount the finger has moved, and apply a rotation to this gameobject based on that amount
					Vector2 fingMove = fing.deltaPosition;
					//float deltaX = (fingMove.y * moveSpeed * -1);
					float deltaY = (fingMove.x * moveSpeed * -1);

					this.transform.Rotate (deltaX, deltaY, 0);
				}
			}
		}*/

		void processTap()
		{
			if (Input.touchCount == 1) 
			{
				//Store input
				Touch fing = Input.GetTouch (0);

				if (fing.phase == TouchPhase.Began)	//If the finger started touching the screen this frame
				{
					if(!EventSystem.current.IsPointerOverGameObject(fing.fingerId))	//And the finger on the screen is not currently touching an object
						startPos = fing.position;	//Get the screen position of the finger when it hit the screen
				} 
				else if (fing.phase == TouchPhase.Ended)	//If the finger stopped touching the screen this frame
				{
					endPos = fing.position;			//Get the screen position of the finger when it left the screen

					if (Mathf.Abs(endPos.magnitude - startPos.magnitude) < roughDiff)	//Calculate how far away the finger was from its starting point when it left the screen, and if it left the screen roughly where it started, it's a tap
					{
						if (_kudanTracker.CurrentTrackingMethod == _markerlessTracking)
						{
							Vector3 position;
							Quaternion orientation;

							_kudanTracker.FloorPlaceGetPose (out position, out orientation);
							_kudanTracker.ArbiTrackStart (position, orientation);
						}
					}
				}
			}
		}
		#endif
	}
}