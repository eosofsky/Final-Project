using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchHare : MonoBehaviour, Interactable {

	public GameObject sprite;
	public Sprite icon;

	private Animator anim;

	private static bool freed = false;

	void Awake () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (sprite.activeSelf && Input.GetKeyDown (KeyCode.E)) {
			anim.SetBool ("Freed", true);
			freed = true;
			string[] lines = {
				"Thanks for freeing me from that\ndeadlock, Alice!",
				"The White Rabbit has really caused\na lot of damage around here!",
				"Now go talk to the Mad\nHacker!"
			};
			Speech.Instance.Speak (lines, "March Hare", 0.0f, HackerDialogue.Advance, icon);
		}
	}

	public void Interact () {
		if (Alice.hasKey && !freed) {
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
