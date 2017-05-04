﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTerminal : MonoBehaviour, Interactable {

    public GameObject sprite;

    public string quitScene;

	public static bool canOpen = true;

	public void Interact () {
		if (canOpen) {
			Filesystem.quitScene = quitScene;
			SceneManager.LoadScene ("Terminal");
		}
    }

    public void PlayerEntry()
    {
        sprite.SetActive(true);
    }

    public void PlayerExit()
    {
        sprite.SetActive(false);
    }
}
