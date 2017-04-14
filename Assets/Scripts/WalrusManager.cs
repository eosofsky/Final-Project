using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalrusManager : MonoBehaviour {

	private static bool walrusLives = true;

	void Start () {
		if (!walrusLives) {
			Destroy (GameObject.Find ("walrus"));
		}
	}

	public static void KillWalrus () {
		walrusLives = false;
	}
}
