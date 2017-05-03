using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceMovement : MonoBehaviour {

	public float speed;

	public static bool hasStarted = false;
	public static Vector3 position;

	private CharacterController characterController;
	private Animator anim;
	private static bool enabled;

	void Awake () {
		characterController = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
		enabled = true;
		if (hasStarted) {
			gameObject.transform.position = position;
		}
		hasStarted = true;
	}

	void OnDestroy () {
		position = gameObject.transform.position;
	}

	void Update () {
		if (enabled) {
			Move ();
		}

		/* Move camera to follow Alice */
		Vector3 target = transform.position;
		target.z = Camera.main.transform.position.z;
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, target, 1f);
	}

	void Move () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if (h < 0.0f && anim) {
			anim.SetBool ("GoingLeft", true);
			anim.SetBool ("GoingRight", false);
		} else if (h > 0.0f && anim) {
			anim.SetBool ("GoingRight", true);
			anim.SetBool ("GoingLeft", false);
		} else if (v > 0.0f && anim) {
			anim.SetBool ("GoingRight", true);
			anim.SetBool ("GoingLeft", false);
		} else if (v < 0.0f && anim) {
			anim.SetBool ("GoingLeft", true);
			anim.SetBool ("GoingRight", false);
		} else if (anim) {
			anim.SetBool ("GoingLeft", false);
			anim.SetBool ("GoingRight", false);
		}
		Vector3 movement = new Vector3 (speed * h, speed * v, 0.0f);
		characterController.Move (movement);
	}

	public static void EnableMovement() {
		enabled = true;
	}

	public static void DisableMovement() {
		enabled = false;
	}

}
