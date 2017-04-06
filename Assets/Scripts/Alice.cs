using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : MonoBehaviour {

	public static bool hasHammer;
	public static bool hasHat;

	void Awake () {
		hasHammer = false;
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		Interactable interactable = hit.collider.gameObject.GetComponent<Interactable> ();
		if (interactable != null) {
			interactable.Interact ();
		}
	}
}
