using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFiles : MonoBehaviour {

	public Sprite fileIcon;

	private static Sprite staticFileIcon;
	private static Transform t;
	private static bool shouldShow = false;

	void Awake () {
		staticFileIcon = fileIcon;
		t = transform;
		if (shouldShow) {
			for (int i = 0; i < t.childCount; i++) {
				t.GetChild (i).GetComponent<SpriteRenderer> ().enabled = true;
			}
		}
	}

	public static void ShowFiles () {
		shouldShow = true;
	}

	public static void FilesSpeak () {
		string[] lines = {"What on earth is happening?", "I have a shipment of Tweets headed\nfor Server C and now I’m stuck here!!"};
		Speech.Instance.Speak (lines, "Twitterdrump", 115.0f, Next, staticFileIcon);
	}

	private static void Next () {
		string[] lines = {"I heard there was a fire on the bus\nroute.", "Someone needs to fix it."};
		Speech.Instance.Speak (lines, "Googledee", 115.0f, CatDialogue.Advance, staticFileIcon);
	}

	/*public static void HideFiles () {
		GameObject randomFile1 = GameObject.Find ("Random File 1");
		GameObject randomFile2 = GameObject.Find ("Random File 2");
		randomFile1.GetComponent<SpriteRenderer> ().enabled = false;
		randomFile2.GetComponent<SpriteRenderer> ().enabled = false;
	}*/

}
