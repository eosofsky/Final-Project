using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitDialogue : MonoBehaviour {

	public Sprite myIcon;

	private static int step = -1;
	private static bool stepStarted = false;
	private static string myName = "White Rabbit";
	private static Sprite staticIcon;

	void Awake () {
		staticIcon = myIcon;
	}

	void Update () {
		if (!stepStarted) {
			switch (step) {
			case 0:
				stepStarted = true;
				RabbitDialogue0 ();
				break;
			case 1:
				stepStarted = true;
				RabbitDialogue1 ();
				break;
			default:
				break;
			}
		}
	}

	public static void RabbitDialogue0 () {
		GameObject Rabbit = GameObject.Find ("Rabbit");
		string[] lines = { "So you found me trolololol!!!\nSo what? It’s too late to stop me now! "};
		Speech.Instance.Speak (lines, myName, 250.0f, AliceDialogue.Advance, staticIcon);
	}

	public static void RabbitDialogue1 () {
		GameObject Rabbit = GameObject.Find ("Rabbit");
		// if (core files not destroyed) {
		string[] lines = {
			"Trololololo!!! What a complete amateur you are!", "Everyone knows that a good hacker would\nkeep multiple backups of his CORE files!",
			"You’ll never be able to take me down!!"
		};
		Speech.Instance.Speak (lines, myName, 250.0f, null, staticIcon);
		//} else {
			//string[] lines = {
				//"Trololololo!!! What a complete amateur you are!", "Everyone knows that a good\nhacker would keep multiple backups of his CORE files!",
				//"Wait.. No! IT CAN’T BE! YOU DESTROYED MY CORE FILES.. NO NO NOOOO!!!?"
			//};
			//Speech.Instance.Speak (lines, Rabbit.transform, 250.0f, End game);
		//}
	}

	public static void Advance () {
		if (step < -1) {
			step = -step;
		} else {
			step++;
		}
		stepStarted = false;
	}
}
