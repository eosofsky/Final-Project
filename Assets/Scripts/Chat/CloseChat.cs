﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseChat : MonoBehaviour {

	private static bool canClose;

	public void Close () {
		if (canClose) {
			SceneManager.LoadScene ("Hub");
		}
	}

	public static void Enable () {
		canClose = true;
	}

	public static void Disable () {
		canClose = false;
	}
}