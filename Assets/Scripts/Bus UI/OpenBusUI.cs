using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBusUI : MonoBehaviour, Interactable {

    public GameObject sprite;

	public static bool canOpen = true;

	public void Interact () {
		if (canOpen) {
			SceneManager.LoadScene ("Bus UI");
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
