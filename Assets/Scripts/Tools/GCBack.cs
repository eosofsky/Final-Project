using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GCBack : MonoBehaviour {

	public void GoBack () {
		Filesystem.canEdit [Filesystem.GetIndexFromFilename ("GarbageCollector.cs")] = false;
		Carpenter.isFixed = true;
		AliceDialogue.Advance ();
		Tunnel.shouldBeOnFire = true;
		RandomFiles.ShowFiles ();
		SceneManager.LoadScene ("Terminal");
	}
}
