using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oyster : MonoBehaviour, Interactable {

	public GameObject sprite;
	public GameObject GoodOyster;
	public GameObject BadOyster;

	private static bool defeated1 = false;
	private static bool defeated2 = false;

	public void Interact () {
		if (SceneManager.GetActiveScene ().Equals ("Core Room") && !defeated1 && Alice.hasHammer) {
			Alice.Hammer ();
			defeated1 = true;
			GoodOyster.gameObject.SetActive (false);
			BadOyster.gameObject.SetActive (true);
			Alice.numCoreFiles++;
		} else if (SceneManager.GetActiveScene ().Equals ("Core Room 2")&& !defeated2 && Alice.hasHammer) {
			Alice.Hammer ();
			defeated2 = true;
			GoodOyster.gameObject.SetActive (false);
			BadOyster.gameObject.SetActive (true);
			Alice.numCoreFiles++;
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
