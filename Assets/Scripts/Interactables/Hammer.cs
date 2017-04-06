using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour, Interactable {

	public void Interact () {
		Alice.hasHammer = true;
		Destroy (gameObject);
	}
}
