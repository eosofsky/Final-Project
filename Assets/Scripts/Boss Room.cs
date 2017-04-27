using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour {

	void Awake () {
		Filesystem.visible [Filesystem.GetIndexFromFilename ("Anti-virus.exe")] = true;
		Filesystem.canRun [Filesystem.GetIndexFromFilename ("Anti-virus.exe")] = true;
	}

	void OnDestroy () {
		Filesystem.visible [Filesystem.GetIndexFromFilename ("Anti-virus.exe")] = false;
		Filesystem.canRun [Filesystem.GetIndexFromFilename ("Anti-virus.exe")] = false;
	}
}
