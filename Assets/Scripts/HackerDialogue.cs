using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerDialogue : MonoBehaviour {

	public Sprite myIcon;

	private static int step = -1;
	private static bool stepStarted = false;
	private static string myName = "Mad Hacker";
	private static Sprite staticIcon;
	private static Animator anim;
	//private static bool isTiming = false;
	//private static float time = 0.0f;
	//private static float delay = 5.0f;

	void Awake () {
		staticIcon = myIcon;
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (!stepStarted) {
			switch (step) {
			case 0:
				stepStarted = true;
				HackerDialogue0 ();
				break;
			case 1:
				stepStarted = true;
				HackerDialogue1 ();
				break;
			case 2:
				stepStarted = true;
				HackerDialogue2 ();
				break;
			case 3:
				stepStarted = true;
				HackerDialogue3 ();
				break;
			case 4:
				stepStarted = true;
				HackerDialogue4 ();
				break;
			default:
				break;
			}
		}

		/*if (isTiming) {
			time += Time.deltaTime;
			if (time >= delay) {
				isTiming = false;
				Advance ();
			}
		}*/
	}

	public static void HackerDialogue0 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"This is outrageous!", "I've got all these important\ninvestments, and this bus stops running.", "Wait till I get my hands on the\npunk that caused it!", "You there! Aren’t you the engineer?", "I can’t believe you took so long to\nfix this mess."};
		Speech.Instance.Speak (lines, myName, 250.0f, AliceDialogue.Advance, staticIcon);
	}

	public static void HackerDialogue1 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"That pesky virus??", "You need to do much better than\nthis if you want to stop him!", "Catching him is not enough.", "ALL skilled hackers know...", "a smart virus would distribute\nits CORE FILES over several servers.", "Even if you destroyed its main body,", "he could simply regenerate himself\nfrom the CORE FILES."};
		Speech.Instance.Speak (lines, myName, 250.0f, AliceDialogue.Advance, staticIcon);
	}

	public static void HackerDialogue2 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"He probably has them hidden in\nsecure, hidden places.", "Of course I know how to reach them...\nBut I’m not obligated to tell you."};
		Speech.Instance.Speak (lines, myName, 250.0f, null, staticIcon);
	}

	public static void HackerDialogue3 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"You know what, I would rather you got\nrid of that furball quick,", "so I will give you my special hat."};
		Speech.Instance.Speak (lines, myName, 250.0f, Advance, staticIcon);
	}

	public static void HackerDialogue4 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"Wearing it gives you special\nprivileges.", "It allows you to see hidden files\nand bypass obstruction..", "Press H to wear Hat and enter\nprivileged mode."};
		Debug.Log ("Giving hat");
		Speech.Instance.Speak (lines, myName, 250.0f, GiveHat, staticIcon);
	}

	public static void GiveHat () {
		anim.SetTrigger ("Clone");
		Alice.hasHat = true;
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
