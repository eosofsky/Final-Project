using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tools : MonoBehaviour {

	private Toggle flamingoToggle;
	private Toggle hammerToggle;
	private Toggle scissorToggle;

	void Start () {
		flamingoToggle = GameObject.Find ("flamingoToggle").GetComponent<Toggle> ();
		hammerToggle = GameObject.Find ("hammerToggle").GetComponent<Toggle> ();
		scissorToggle = GameObject.Find ("scissorsToggle").GetComponent<Toggle> ();

		hammerToggle.isOn = Alice.hasHammer;
	}

	public void ToggleHammer () {
		if (hammerToggle.isOn) {
			Alice.hasHammer = true;
		} else {
			Alice.hasHammer = false;
		}
	}

	public void ToggleFlamingo () {
		// TODO: Implement
	}

	public void ToggleScissors () {
		// TODO: Implement
	}
}
