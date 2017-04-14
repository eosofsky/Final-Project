using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTerminal : MonoBehaviour, Interactable {

	public void Interact () {
		SceneManager.LoadScene ("Terminal");
	}
}
