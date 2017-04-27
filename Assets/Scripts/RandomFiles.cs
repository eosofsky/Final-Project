using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFiles : MonoBehaviour {

	public static void FilesSpeak () {
		GameObject randomFile1 = GameObject.Find ("Random File 1");
		GameObject randomFile2 = GameObject.Find ("Random File 2");
		randomFile1.GetComponent<SpriteRenderer> ().enabled = true;
		randomFile2.GetComponent<SpriteRenderer> ().enabled = true;
		string[] lines = {"What on earth is happening?", "I have a whole shipment of Tweets headed\nfor Server C and now I’m stuck here!!"};
		Speech.Instance.Speak (lines, randomFile1.transform, 115.0f, Next);
	}

	private static void Next () {
		GameObject randomFile2 = GameObject.Find ("Random File 2");
		string[] lines = {"I heard there was a fire on the train lines..", "Someone needs to fix it."};
		Speech.Instance.Speak (lines, randomFile2.transform, 115.0f, CatDialogue.Advance);
	}

	/*public static void HideFiles () {
		GameObject randomFile1 = GameObject.Find ("Random File 1");
		GameObject randomFile2 = GameObject.Find ("Random File 2");
		randomFile1.GetComponent<SpriteRenderer> ().enabled = false;
		randomFile2.GetComponent<SpriteRenderer> ().enabled = false;
	}*/

}
