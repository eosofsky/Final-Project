using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour, Interactable {

	public string destinationName;
	public string sourceName;

	public void Interact () {
		SourceManager.oldScene = sourceName;
		SceneManager.LoadScene (destinationName);
		AliceMovement.hasStarted = false;
	}
}
