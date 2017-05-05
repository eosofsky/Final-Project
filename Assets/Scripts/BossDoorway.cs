using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDoorway : MonoBehaviour, Interactable {

	public static bool canPass = false;

	public string destinationName;
	public string sourceName;

	public void Interact () {
		if (canPass) {
			Filesystem.visible [Filesystem.GetIndexFromFilename ("Anti-virus.exe")] = false;
			Filesystem.canRun [Filesystem.GetIndexFromFilename ("Anti-virus.exe")] = false;
			SourceManager.oldScene = sourceName;
			SceneManager.LoadScene (destinationName);
			AliceMovement.hasStarted = false;
		}
	}

    public void PlayerEntry()
    { }

    public void PlayerExit()
    { }
}
