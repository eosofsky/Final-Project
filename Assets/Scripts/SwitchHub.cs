using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHub : MonoBehaviour, Interactable {

	public GameObject sprite;

	public static bool ignite = false;
	public static bool hasIgnited = false;

	void Awake () {
		if (ignite && !hasIgnited) {
			AliceDialogue.Advance ();
			hasIgnited = true;
		}
	}

	public static void Ignite () {
		ignite = true;
		// Ignite
	}

	void Update () {
		if (sprite.activeSelf && Input.GetKeyDown (KeyCode.E)) {
			ignite = false;
			// Extinguish
			Mail.Activate ();
			BusStation.busIsFixed = true;
			Tunnel.shouldBeOnFire = false;
		}
	}

	public void Interact () {
		if (ignite && Alice.foundExtinguisher) {
			PlayerEntry ();
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
