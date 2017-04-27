using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDialogue : MonoBehaviour {

	private static int step = -1;
	private static bool stepStarted = false;
	private static bool isTiming = false;
	private static float time = 0.0f;
	private static float delay = 5.0f;

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
		string[] lines = { "Alice, what took you\nso long to get here!!", "We’ll all be screwed over if the\nWhite Rabbit gets what he wants!"};
		Speech.Instance.Speak (lines, Cat.transform, 250.0f, AliceDialogue.Advance);
	}

	public static void CatDialogue1 () {
		GameObject Cat = GameObject.Find ("Cat");
		string[] lines = { "Depends on where you want to end up!\nNot in this mess I hope..."};
		Speech.Instance.Speak (lines, Cat.transform, 200.0f, Disappear);
	}

	public static void CatDialogue2 () {
		GameObject Cat = GameObject.Find ("Cat");
		SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
		render.enabled = true;
		string[] lines = { "Oh.. Looks like the White Rabbit\nreally messed things up here!", "Walrus the garbage collector is just\nnot doing his job properly anymore."};
		Speech.Instance.Speak (lines, Cat.transform, 200.0f, StartTimer);
	}

	public static void CatDialogue3 () {
		GameObject Cat = GameObject.Find ("Cat");
		string[] lines = { "The thing about memory, Alice,", "is that it needs to be cleared when\nit is not being used anymore!\nNot when it is still in use!", "No wonder things are messing up."};
		Speech.Instance.Speak (lines, Cat.transform, 200.0f, StartTimer);
	}

	public static void CatDialogue4 () {
		GameObject Cat = GameObject.Find ("Cat");
		string[] lines = { "Clearly, the garbage collector is not doing his job properly.."};
		Speech.Instance.Speak (lines, Cat.transform, 200.0f, DisappearAndAdvanceAlice);
	}

	public static void CatDialogue5 () {
		GameObject Cat = GameObject.Find ("Cat");
		SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
		render.enabled = true;
		string[] lines = {"..And FAST! I’m sure that sleazy cottontail\nhas terrible things up his sleeve.", "You should probably head to Server B. Get a grip!!"};
		Speech.Instance.Speak (lines, Cat.transform, 200.0f, DisappearAndFilesSpeak);
	}

	public static void CatDialogue6 () {
		GameObject Cat = GameObject.Find ("Cat");
		SpriteRenderer render = Cat.gameObject.GetComponent<SpriteRenderer> ();
		render.enabled = true;
		string[] lines = {"A fire? Must be the White\nRabbit’s doing again!"};
		Speech.Instance.Speak (lines, Cat.transform, 200.0f, IgniteAndDisappear);
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
		step++;
		stepStarted = false;
	}
}
