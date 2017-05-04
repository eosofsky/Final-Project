using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDialogue : MonoBehaviour {

	public Sprite myIcon;

	private static int step = -1;
	private static string myName = "Cheshire Cat";
	private static bool stepStarted = false;
	private static bool isTiming = false;
	private static float time = 0.0f;
	private static float delay = 5.0f;
	private static Sprite staticIcon;

	void Awake () {
		staticIcon = myIcon;
	}

	void Update () {
		if (!stepStarted) {
			switch (step) {
			case 0:
				stepStarted = true;
				CatDialogue0 ();
				break;
			case 1:
				stepStarted = true;
				CatDialogue1 ();
				break;
			case 2:
				stepStarted = true;
				CatDialogue2 ();
				break;
			case 3:
				stepStarted = true;
				CatDialogue3 ();
				break;
			case 4:
				stepStarted = true;
				CatDialogue4 ();
				break;
			case 5:
				stepStarted = true;
				CatDialogue5 ();
				break;
			case 6:
				stepStarted = true;
				CatDialogue6 ();
				break;
			case 7:
				stepStarted = true;
				CatDialogue7 ();
				break;
			default:
				break;
			}
		}

		if (isTiming) {
			time += Time.deltaTime;
			if (time >= delay) {
				isTiming = false;
				Advance ();
			}
		}
	}

	public static void CatDialogue0 () {
		GameObject Cat = GameObject.Find ("Cat");
		SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
		render.enabled = true;
		string[] lines = { "Alice, what took you so long to\nget here?!", "We’ll all be screwed over if the\nWhite Rabbit gets what he wants!"};
		Speech.Instance.Speak (lines, myName, 250.0f, AliceDialogue.Advance, staticIcon);
	}

	public static void CatDialogue1 () {
		GameObject Cat = GameObject.Find ("Cat");
		string[] lines = { "Depends on where you want to end up!\nNot in this mess I hope..."};
		Speech.Instance.Speak (lines, myName, 200.0f, Disappear, staticIcon);
	}

	public static void CatDialogue2 () {
		GameObject Cat = GameObject.Find ("Cat");
		SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
		render.enabled = true;
		string[] lines = { "Oh... Looks like the White Rabbit\nreally messed things up here!", "The garbage collector is just\nnot doing his job properly anymore.",  "The thing about memory, Alice, is\nthat it needs to be cleared when", "it is not being used anymore! Not\nwhen it is still in use!", "Clearly, the garbage collector is\nnot doing his job properly..."};
		Speech.Instance.Speak (lines, myName, 200.0f, /*StartTimer*/Advance, staticIcon);
	}

	public static void CatDialogue3 () {
		//GameObject Cat = GameObject.Find ("Cat");
		//string[] lines = { "The thing about memory, Alice, is\nthat it needs to be cleared when", "it is not being used anymore! Not\nwhen it is still in use!"};
		//Speech.Instance.Speak (lines, myName, 200.0f, /*StartTimer*/Advance, staticIcon);
		Advance();
	}

	public static void CatDialogue4 () {
		//GameObject Cat = GameObject.Find ("Cat");
		//string[] lines = { "Clearly, the garbage collector is\nnot doing his job properly.."};
		//Speech.Instance.Speak (lines, myName, 200.0f, DisappearAndAdvanceAlice, staticIcon);
		DisappearAndAdvanceAlice();
	}

	public static void CatDialogue5 () {
		GameObject Cat = GameObject.Find ("Cat");
		SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
		render.enabled = true;
		string[] lines = {"I’m sure that sleazy cottontail has\nterrible things up his sleeve.", "You should probably head to Server\nB. Get a grip!!"};
		Speech.Instance.Speak (lines, myName, 200.0f, DisappearAndFilesSpeak, staticIcon);
	}

	public static void CatDialogue6 () {
		GameObject Cat = GameObject.Find ("Cat");
		SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
		render.enabled = true;
		string[] lines = {"A fire? Must be the White Rabbit’s\ndoing again!", "You probably can’t do anything\nhere...", "But in the world outside, maybe\nyou can..."};
		Speech.Instance.Speak (lines, myName, 200.0f, IgniteAndDisappear, staticIcon);
	}

	public static void CatDialogue7 () {
		if (!Alice.hasHammer) {
			GameObject Cat = GameObject.Find ("Cat");
			SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
			render.enabled = true;
			string[] lines = {
				"Looks like you may need to go back\nto the software to fix this silverware!",
				"Maybe there are some tools you \ncan use?"
			};
			Speech.Instance.Speak (lines, myName, 200.0f, Disappear, staticIcon);
		}
	}

	private static void DisappearAndAdvanceAlice () {
		Disappear ();
		AliceDialogue.Advance ();
	}

	private static void DisappearAndFilesSpeak () {
		Disappear ();
		RandomFiles.FilesSpeak ();
	}

	private static void IgniteAndDisappear () {
		Disappear ();
		SwitchHub.ignite = true;
	}

	private static void Disappear () {
		GameObject Cat = GameObject.Find ("Cat");
		SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
		render.enabled = false;
	}

	private static void StartTimer () {
		time = 0.0f;
		isTiming = true;
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
