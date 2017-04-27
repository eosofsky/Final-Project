using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour {

	private static bool isActive = false;
	private static bool justToggled = false;

	void Update () {
		if (justToggled) {
			SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer> ();
			BoxCollider[] colliders = GetComponentsInChildren<BoxCollider> ();
			for (int i = 0; i < renderers.Length; i++) {
				renderers [i].enabled = isActive;
				colliders [i].enabled = isActive;
			}

			justToggled = false;
		}
	}

	public static void Activate () {
		isActive = true;
		justToggled = true;
	}

	public static void Deactivate () {
		isActive = false;
		justToggled = true;
	}
}
