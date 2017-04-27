using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filesystem : MonoBehaviour {

	public string[] myFiles;
	public bool[] myCanEdit;
	public bool[] myCanDelete;
	public bool[] myCanRun;
	public bool[] myVisible;
	public static string quitScene;

	public static string[] files;
	public static bool[] canEdit;
	public static bool[] canDelete;
	public static bool[] canRun;
	public static bool[] visible;

	private static bool hasLoaded = false;

	void Awake () {
		if (!hasLoaded) {
			files = myFiles;
			canEdit = myCanEdit;
			canDelete = myCanDelete;
			canRun = myCanRun;
			visible = myVisible;
		}
		hasLoaded = true;
	}

	public static int GetIndexFromFilename (string filename) {
		for (int i = 0; i < files.Length; i++) {
			if (files [i].Equals (filename)) {
				return i;
			}
		}

		/* Not found */
		return -1;
	}

}
