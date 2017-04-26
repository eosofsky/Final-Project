using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceMovement : MonoBehaviour {

	public float speed;

	public static bool hasStarted = false;
	public static Vector3 position;

	private CharacterController characterController;
	private static bool enabled;

	void Awake () {
		characterController = GetComponent<CharacterController> ();
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
		Vector3 movement = new Vector3 (speed * Input.GetAxis ("Horizontal"), speed * Input.GetAxis ("Vertical"), 0.0f);
		characterController.Move (movement);
	}

	public static void EnableMovement() {
		enabled = true;
	}

	public static void DisableMovement() {
		enabled = false;
	}

}
