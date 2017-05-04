using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseChat : MonoBehaviour {

	private static bool canClose;

	public void Close () {
		if (canClose) {
			SceneManager.LoadScene ("Hub");
		}
	}

	public static void Enable () {
		GameObject.Find ("X Text").GetComponent<Text> ().color = Color.white;
		canClose = true;
	}

	public static void Disable () {
		canClose = false;
	}
}
