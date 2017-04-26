using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filesystem : MonoBehaviour {

	public string[] myFiles;
	public bool[] myCanEdit;
	public bool[] myCanDelete;
	public bool[] myCanRun;
	public static string quitScene;

	public static string[] files;
	public static bool[] canEdit;
	public static bool[] canDelete;
	public static bool[] canRun;

	private static bool hasLoaded = false;

	void Awake () {
		if (!hasLoaded) {
			files = myFiles;
			canEdit = myCanEdit;
			canDelete = myCanDelete;
			canRun = myCanRun;
		}
		hasLoaded = true;
	}

}
