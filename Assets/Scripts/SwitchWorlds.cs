using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorlds : MonoBehaviour {

	private int physicalWorldMask;
	private int digitalWorldMask;
	private bool showingPhysicalWorld;

	void Awake () {
		physicalWorldMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Digital World"));
		digitalWorldMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Physical World"));
		/* Start in physical world */
		showingPhysicalWorld = false;
		Switch ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Switch ();
		}
	}

	public void Switch () {
		/* Disable old world's colliders */
		string tag = showingPhysicalWorld ? "PhysicalWorld" : "DigitalWorld";
		GameObject[] objs = GameObject.FindGameObjectsWithTag (tag);
		for (int i = 0; i < objs.Length; i++) {
			Collider collider = objs [i].GetComponent <Collider> ();
			if (collider) {
				collider.enabled = false;
			}
		}

		/* Enable new world's colliders */
		tag = showingPhysicalWorld ? "DigitalWorld" : "PhysicalWorld";
		objs = GameObject.FindGameObjectsWithTag (tag);
		for (int i = 0; i < objs.Length; i++) {
			Collider collider = objs [i].GetComponent <Collider> ();
			if (collider) {
				collider.enabled = true;
			}
		}

		/* Make other world invisible */
		Camera.main.cullingMask = showingPhysicalWorld ? digitalWorldMask : physicalWorldMask;
		showingPhysicalWorld = !showingPhysicalWorld;
	}
}
