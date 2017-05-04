using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFiles : MonoBehaviour {

	public Sprite file1Icon;
	public Sprite file2Icon;

	private static Sprite staticFile1Icon;
	private static Sprite staticFile2Icon;

	void Awake () {
		staticFile1Icon = file1Icon;
		staticFile2Icon = file2Icon;
	}

	public static void FilesSpeak () {
		GameObject randomFile1 = GameObject.Find ("Random File 1");
		GameObject randomFile2 = GameObject.Find ("Random File 2");
		randomFile1.GetComponent<SpriteRenderer> ().enabled = true;
		randomFile2.GetComponent<SpriteRenderer> ().enabled = true;
		string[] lines = {"What on earth is happening?", "I have a shipment of Tweets headed\nfor Server C and now I’m stuck here!!"};
		Speech.Instance.Speak (lines, "Twitter.com", 115.0f, Next, staticFile1Icon);
	}

	private static void Next () {
		GameObject randomFile2 = GameObject.Find ("Random File 2");
		string[] lines = {"I heard there was a fire on the bus\nroute.", "Someone needs to fix it."};
		Speech.Instance.Speak (lines, "Google.com", 115.0f, CatDialogue.Advance, staticFile2Icon);
	}

	/*public static void HideFiles () {
		GameObject randomFile1 = GameObject.Find ("Random File 1");
		GameObject randomFile2 = GameObject.Find ("Random File 2");
		randomFile1.GetComponent<SpriteRenderer> ().enabled = false;
		randomFile2.GetComponent<SpriteRenderer> ().enabled = false;
	}*/

}
