using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour {

	public Dropdown[] dropdowns;
	public int[] answers;

	private Text text;
	private Button button;

	void Awake () {
		text = GetComponentInChildren<Text> ();
		button = GetComponent<Button> ();
	}

	void Update () {
		if (Check ()) {
			button.interactable = true;
			text.color = new Color (3.0f / 255.0f, 244.0f / 255.0f, 0.0f);
		} else {
			button.interactable = false;
			text.color = new Color (131.0f / 255.0f, 131.0f / 255.0f, 131.0f / 255.0f);
		}
	}

	private bool Check () {
		bool correct = false;
		/* Check first possible set of answers */
		int i;
		for (i = 0; i < dropdowns.Length; i++) {
			if (dropdowns [i].value != answers [i]) {
				break;
			}
		}
		if (i == dropdowns.Length) {
			correct = true;
		}

		return correct;
	}
}
