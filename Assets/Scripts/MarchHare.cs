﻿using System.Collections;
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

	public void Interact () {
		if (Alice.hasKey && !freed) {
			anim.SetBool ("Freed", true);
			freed = true;
			string[] lines = {"Thanks for freeing me from that\ndeadlock Alice!", "The White Rabbit has really caused\na lot of damage around here!"};
			Speech.Instance.Speak (lines, "March Hare", 0.0f, HackerDialogue.Advance, icon);
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