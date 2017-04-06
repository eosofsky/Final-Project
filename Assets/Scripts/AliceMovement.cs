using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceMovement : MonoBehaviour {

	public float speed;

	private CharacterController characterController;

	void Awake () {
		characterController = GetComponent<CharacterController> ();
	}

	void Update () {
		Move ();

		/* Move camera to follow Alice */
		Vector3 target = transform.position;
		target.z = Camera.main.transform.position.z;
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, target, 1f);
	}

	void Move () {
		Vector3 movement = new Vector3 (speed * Input.GetAxis ("Horizontal"), speed * Input.GetAxis ("Vertical"), 0.0f);
		characterController.Move (movement);
	}

}
