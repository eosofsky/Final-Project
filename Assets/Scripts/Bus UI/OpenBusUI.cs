using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBusUI : MonoBehaviour, Interactable {

	public static bool canOpen = true;

	public void Interact () {
		if (canOpen) {
			SceneManager.LoadScene ("Bus UI");
		}
	}
}
