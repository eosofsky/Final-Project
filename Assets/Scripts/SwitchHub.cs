using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHub : MonoBehaviour, Interactable {

	public GameObject sprite;

	public static bool ignite = false;
	public static bool hasIgnited = false;

	private static SpriteRenderer sr;

	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
		if (ignite) {
			if (!hasIgnited) {
				AliceDialogue.Advance ();
				hasIgnited = true;
			}
			sr.enabled = true;
		}
	}

	public static void Ignite () {
		ignite = true;
		sr.enabled = true;
	}

	void Update () {
		if (sprite.activeSelf && Input.GetKeyDown (KeyCode.E)) {
			Alice.ExtinguishFire ();
			ignite = false;
			sr.enabled = false;
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
