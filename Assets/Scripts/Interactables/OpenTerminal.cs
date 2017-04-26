using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTerminal : MonoBehaviour, Interactable {

	public string quitScene;

	public void Interact () {
		Filesystem.quitScene = quitScene;
		SceneManager.LoadScene ("Terminal");
	}
}
