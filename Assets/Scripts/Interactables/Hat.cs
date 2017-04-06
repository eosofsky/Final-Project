using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour, Interactable {

	public void Interact () {
		Alice.hasHat = true;
		Destroy (gameObject);
	}
}
