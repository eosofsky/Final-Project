using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorlds : MonoBehaviour {

	private int world1Mask; /* Shows all but world2 */
	private int world2Mask; /* Shows all but world1 */
	private bool showingWorld1;

	void Awake () {
		world1Mask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("World 2"));
		world2Mask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("World 1"));
		/* Start in world1 */
		showingWorld1 = false;
		Switch ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Switch ();
		}
	}

	public void Switch () {
		/* Disable old world's colliders */
		string tag = showingWorld1 ? "World1" : "World2";
		GameObject[] objs = GameObject.FindGameObjectsWithTag (tag);
		for (int i = 0; i < objs.Length; i++) {
			//Rigidbody rb = objs [i].GetComponent <Rigidbody> ();
			Collider collider = objs [i].GetComponent <Collider> ();
			if (collider) {
				collider.enabled = false;
			}
		}

		/* Enable new world's colliders */
		tag = showingWorld1 ? "World2" : "World1";
		objs = GameObject.FindGameObjectsWithTag (tag);
		for (int i = 0; i < objs.Length; i++) {
			Collider collider = objs [i].GetComponent <Collider> ();
			if (collider) {
				collider.enabled = true;
			}
		}

		/* Make other world invisible */
		Camera.main.cullingMask = showingWorld1 ? world2Mask : world1Mask;
		showingWorld1 = !showingWorld1;
	}
}
