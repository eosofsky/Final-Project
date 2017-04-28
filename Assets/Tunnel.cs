using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour {

	public static bool shouldBeOnFire = false;

	void Awake () {
		if (shouldBeOnFire) {
			Animator anim = GetComponent<Animator> ();
			anim.SetBool ("OnFire", true);
		}
	}
}
