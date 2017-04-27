using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour {

	public Dropdown[] dropdowns;
	public int[] answers;

	public void Check () {
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

		if (correct) {
			Back back = GetComponent<Back> ();
			back.GoBack ();
			AliceDialogue.Advance ();
		}
	}
}
