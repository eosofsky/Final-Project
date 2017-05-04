using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyster : MonoBehaviour, Interactable {

	public GameObject sprite;
	public GameObject GoodOyster;
	public GameObject BadOyster;

	private static bool defeated = false;

	public void Interact () {
		if (!defeated && Alice.hasHammer) {
			Alice.Hammer ();
			defeated = true;
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
