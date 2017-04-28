using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour, Interactable {

	public static bool canPass = false;

	public string destinationName;
	public string sourceName;

	public void Interact () {
		if (canPass) {
			if (destinationName.Equals ("Bus Station")) {
				if (SourceManager.oldScene.Equals ("Bus Exterior 1") || SourceManager.oldScene.Equals ("Bus Exterior 2")) {
					destinationName = "Bus Station 1";
				} else if (SourceManager.oldScene.Equals ("Bus 2 Exterior 1") || SourceManager.oldScene.Equals ("Bus 2 Exterior 2")) {
					destinationName = "Bus Station 2";
				} else {
					destinationName = "Bus Station 1";
				}
			}
				
			SourceManager.oldScene = sourceName;
			SceneManager.LoadScene (destinationName);
			AliceMovement.hasStarted = false;
		}
	}
}
