using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceDialogue : MonoBehaviour {

	public Sprite myIcon;

	private static int step = -1;
	private static bool stepStarted = false;
	private static Sprite staticIcon;

	private static string myName = "Alice";

	void Awake () {
		staticIcon = myIcon;
	}

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
			case 7:
				stepStarted = true;
				AliceDialogue7 ();
				break;
			case 8:
				stepStarted = true;
				AliceDialogue8 ();
				break;
			case 9:
				stepStarted = true;
				AliceDialogue9 ();
				break;
			default:
				break;
			}
		}
	}

	public static void AliceDialogue0 () {
		string[] lines = { "What on earth is happening!?", "I need to get to a computer\nterminal and figure things out...", "Maybe there's a program I can run\nto help me."};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, "Alice", 250.0f, null, staticIcon);
	}

	public static void AliceDialogue1 () {
		string[] lines = { "Ok. I’m currently in server A.", "I better start fixing things up\nsoon!"};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, myName, 200.0f, CatDialogue.Advance, staticIcon);
	}

	public static void AliceDialogue2 () {
		string[] lines = { "I don’t need you to tell me that!", "Where should I go?"};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, myName, 200.0f, CatDialogue.Advance, staticIcon);
	}

	public static void AliceDialogue3 () {
		string[] lines = { "This is the memory room of Server\nA...", "What a mess! The ready-to-be-freed\nmemory is piling up."};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, myName, 200.0f, CatDialogue.Advance, staticIcon);
	}

	public static void AliceDialogue4 () {
		string[] lines = { "Something must be wrong with his\ncode..."};
		GameObject Alice = GameObject.Find ("Alice");
		Filesystem.canEdit [Filesystem.GetIndexFromFilename ("GarbageCollector.cs")] = true;
		Speech.Instance.Speak (lines, myName, 200.0f, null, staticIcon);
	}

	public static void AliceDialogue5 () {
		string[] lines = { "Great, now the garbage collector is\ndoing what he needs to.", "Urg, I wonder what else the White\nRabbit has messed up."};
		GameObject Alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, myName, 200.0f, CatDialogue.Advance, staticIcon);
	}

	public static void AliceDialogue6 () {
		string[] lines = { "There. That explains it.", "The cables connecting Server A to\nServer B has overheated and burnt down.", "How could this be?", "These wires are able to handle 50GB\nof traffic per minute...", "Unless someone has been transporting\nmore data than that across the wire."};
		GameObject alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, myName, 200.0f, Alice.ExtinguishFire, staticIcon);
	}

	public static void AliceDialogue7 () {
		string[] lines = {"It’s all the White Rabbit’s doing.", "I will stop him before he can wreak\nany more havoc."};
		GameObject alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, myName, 200.0f, HackerDialogue.Advance, staticIcon);
	}

	public static void AliceDialogue8 () {
		string[] lines = {"How would I be able to find those\nCORE FILES?"};
		GameObject alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, myName, 200.0f, HackerDialogue.Advance, staticIcon);
	}

	public static void AliceDialogue9 () {
		string[] lines = {"Damn! White Rabbit is stealing\nall of this data!", "I have to stop him with my virus removal tool!"};
		GameObject alice = GameObject.Find ("Alice");
		Speech.Instance.Speak (lines, myName, 200.0f, null, staticIcon);
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
