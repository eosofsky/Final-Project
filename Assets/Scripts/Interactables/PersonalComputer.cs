using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonalComputer : MonoBehaviour, Interactable {

	private static bool hasStarted = false;

	void Start () {
		string[] lines = {"You've got mail!"};
		if (!hasStarted) {
			Speech.Instance.Speak (lines, transform, 115.0f, DisableTerminalAccess);
		}
	}

	public void Interact () {
		Speech.Instance.StopSpeaking ();
		hasStarted = true;
		SceneManager.LoadScene ("Chat");
	}

	private void DisableTerminalAccess () {
		OpenTerminal.canOpen = false;
	}

}
