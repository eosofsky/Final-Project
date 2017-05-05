using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoom : MonoBehaviour {

	void Awake () {
		RabbitDialogue.Restart ();
		Filesystem.visible [Filesystem.GetIndexFromFilename ("Anti-virus.exe")] = true;
		Filesystem.canRun [Filesystem.GetIndexFromFilename ("Anti-virus.exe")] = true;
	}
}
