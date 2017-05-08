using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabbitDialogue : MonoBehaviour {

	public Sprite myIcon;

	private static int step = -1;
	private static bool stepStarted = false;
	private static string myName = "White Rabbit";
	private static Sprite staticIcon;
	private static bool hasStarted = false;

	void Awake () {
		staticIcon = myIcon;
		if (!hasStarted) {
			Advance ();
		}
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
		if (!hasStarted) {
			GameObject Rabbit = GameObject.Find ("Rabbit");
			string[] lines = { "So you found me trolololol!!!\nSo what? It’s too late to stop me now! " };
			BossDoorway.canPass = false;
			Speech.Instance.Speak (lines, myName, 250.0f, AliceAdvanceAndPass, staticIcon);
			hasStarted = true;
		}
	}

	public static void RabbitDialogue1 () {
		BossDoorway.canPass = false;
		GameObject Rabbit = GameObject.Find ("Rabbit");
		if (Alice.numCoreFiles < 2) {
			string[] lines = {
				"Trololololo!!! What a complete\namateur you are!", "Everyone knows that a good hacker", "would keep multiple backups of his\nCORE files!",
				"You’ll never be able to take me\ndown!!"
			};
			Speech.Instance.Speak (lines, myName, 250.0f, AllowPass, staticIcon);
		} else {
			string[] lines = {
				"Trololololo!!! What a complete\namateur you are!", "Everyone knows that a good hacker", "would keep multiple backups of his\nCORE files!",
				"Wait.. No! IT CAN’T BE! YOU DESTROYED\nMY CORE FILES.. NO NO NOOOO!!!?"
			};
			Speech.Instance.Speak (lines, myName, 250.0f, EndGame, staticIcon);
		}
		step--;
	}

	private static void EndGame () {
		SceneManager.LoadScene ("End");
	}

	private static void AllowPass () {
		BossDoorway.canPass = true;
	}

	private static void AliceAdvanceAndPass () {
		BossDoorway.canPass = true;
		AliceDialogue.Advance ();
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
