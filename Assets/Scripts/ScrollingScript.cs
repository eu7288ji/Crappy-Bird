using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScrollingScript : MonoBehaviour {

	public Vector2 speed = new Vector2 (2, 2); //scroll speed
	public Vector2 direction = new Vector2 (-1, 0); //direction
	public bool isLinkedToCamera = false;
	public bool isLooping = false; //infinite background
	private List<SpriteRenderer> backgroundPart;

	void Start() {

		if (isLooping) {

			backgroundPart = new List<SpriteRenderer> (); //get the children within the layer

			for (int i = 0; i < transform.childCount; i++) {

				Transform child = transform.GetChild (i);
				SpriteRenderer r = child.GetComponent<SpriteRenderer> ();
			
				if (r != null) //only visible children
				{
					backgroundPart.Add (r);
				}
			}
			//ordering children left to right
			backgroundPart = backgroundPart.OrderBy (
				t => t.transform.position.x).ToList ();
		}
	}

	void Update () {

		Vector3 movement = new Vector3 ( //object movement
			                   speed.x * direction.x,
			                   speed.y * direction.y,
			                   0);
		movement *= Time.deltaTime;
		transform.Translate (movement);

		if (isLinkedToCamera) { //camera movement

			Camera.main.transform.Translate(movement);
		}

		if  (isLooping)
		{ //find first object from left > right
			SpriteRenderer firstChild = backgroundPart.FirstOrDefault ();

			if (firstChild != null)
			{
				//if child is to left of camera
				if (firstChild.transform.position.x <
					Camera.main.transform.position.x)
				{
					//if child is completely out of camera view
					if (firstChild.IsVisibleFrom(Camera.main) == false)
					{
						//cycles child back to last position to the right
						SpriteRenderer lastChild =
							backgroundPart.LastOrDefault ();
						Vector3 lastPosition =
							lastChild.transform.position;
						Vector3 lastSize = (lastChild.bounds.max -
						                   lastChild.bounds.min);

						firstChild.transform.position = new
							Vector3 (lastPosition.x + lastSize.x, firstChild.transform.position.y,
							firstChild.transform.position.z);
						//sets child at recycled point, removes one outside of view
						backgroundPart.Remove (firstChild);
						backgroundPart.Add (firstChild);
					}
				}
			}
		}
	}
}

//aspects of this script were adapted from "Parallax Scrolling" tutorial
//http://pixelnest.io/tutorials/2d-game-unity/parallax-scrolling/