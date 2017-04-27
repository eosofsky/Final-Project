using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceDialogue : MonoBehaviour {

	private static int step = -1;
	private static bool stepStarted = false;

	void Update () {
		if (!stepStarted) {
			switch (step) {
			case 0:
				stepStarted = true;
				AliceDialogue0 ();
				break;
			case 1:
				stepStarted = true;
				AliceDialogue1 ();
				break;
			case 2:
				stepStarted = true;
				AliceDialogue2 ();
				break;
			case 3:
				stepStarted = true;
				AliceDialogue3 ();
				break;
			case 4:
				stepStarted = true;
				AliceDialogue4 ();
				break;
			case 5:
				stepStarted = true;
				AliceDialogue5 ();
				break;
			case 6:
				stepStarted = true;
				AliceDialogue6 ();
				break;
			default:
				break;
			}
		}
	}

	public static void AliceDialogue0 () {
		string[] lines = { "What on earth is happening!?", "I need to get inside a computer\nterminal and figure things out.. FAST."};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, Alice.transform, 250.0f, null);
	}

	public static void AliceDialogue1 () {
		string[] lines = { "Ok. I’m currently in server A..", "I better start fixing things up soon,", "every second of downtime means lost revenue."};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, Alice.transform, 200.0f, CatDialogue.Advance);
	}

	public static void AliceDialogue2 () {
		string[] lines = { "Don’t need you to tell me that!", "Where should I go?"};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, Alice.transform, 200.0f, CatDialogue.Advance);
	}

	public static void AliceDialogue3 () {
		string[] lines = { "This is the memory room of Server A...", "What a mess! The unused bad memory\nis overflowing everywhere."};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, Alice.transform, 200.0f, CatDialogue.Advance);
	}

	public static void AliceDialogue4 () {
		string[] lines = { "Something must be wrong with its code.."};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, Alice.transform, 200.0f, null);
	}

	public static void AliceDialogue5 () {
		string[] lines = { "Great, now the garbage collector is doing what it needs to.", "Urg, I wonder what else the\nWhite Rabbit has messed up.", "I better stop him."};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, Alice.transform, 200.0f, CatDialogue.Advance);
	}

	public static void AliceDialogue6 () {
		string[] lines = { "There. That explains it.", "The ethernet cables connecting Server A to\nServer B has overheated and burnt down.", "How could this be?", "These wires are able to handle 50Gbits of\ntraffic per minute… Unless..", "someone has been transporting way more\ndata than that across the wire."};
		GameObject alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, alice.transform, 200.0f, Alice.ExtinguishFire);
	}

	public static void Advance () {
		step++;
		stepStarted = false;
	}
}
