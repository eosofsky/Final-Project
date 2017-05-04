using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpenter : MonoBehaviour {

	public Transform dest;
	public static bool isFixed = false;

	void Awake () {
		Animator anim = GetComponent<Animator> ();
		if (isFixed) {
			anim.SetBool ("Fixed", true);
			transform.position = dest.position;
		}
	}


}
