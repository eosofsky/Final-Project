using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerDialogue : MonoBehaviour {

	private static int step = -1;
	private static bool stepStarted = false;
	//private static bool isTiming = false;
	//private static float time = 0.0f;
	//private static float delay = 5.0f;

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
		string[] lines = {"This is outrageous!", "I've got all these important investments that\nI need to check on, and this bus stops running.", "Wait till I get my hands on the punk that caused it!", "You there! Aren’t you the engineer?", "Do you know how important my investments are!\nI can’t believe you took so long to fix this mess."};
		Speech.Instance.Speak (lines, Hacker.transform, 250.0f, AliceDialogue.Advance);
	}

	public static void HackerDialogue1 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"That pesky virus??", "You need to do much better than\nthis if you want to stop him!", "Catching him is not enough. As ALL skilled hackers know,\na smart virus would distribute its CORE FILES over several servers,\nso even if you destroyed its main body,\nhe could simply regenerate himself from the CORE FILES."};
		Speech.Instance.Speak (lines, Hacker.transform, 250.0f, AliceDialogue.Advance);
	}

	public static void HackerDialogue2 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"He probably has them hidden in secure, hidden places.", "Of course I know how to reach them.. But I’m not obligated to\ntell you. I don’t even like engineers anyway."};
		Speech.Instance.Speak (lines, Hacker.transform, 250.0f, null);
	}

	public static void HackerDialogue3 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"You know what, I would rather you got rid of that\nfurball quick, so I will give you my special hat."};
		Speech.Instance.Speak (lines, Hacker.transform, 250.0f, Advance);
	}

	public static void HackerDialogue4 () {
		GameObject Hacker = GameObject.Find ("Hacker");
		string[] lines = {"Wearing it gives you special privileges. It allows\nyou to see hidden memory/files\nand bypass any obstructions and security.", "Press H to wear Hat and enter privileged mode"};
		Speech.Instance.Speak (lines, Hacker.transform, 250.0f, null);
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
