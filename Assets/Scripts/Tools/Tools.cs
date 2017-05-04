using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tools : MonoBehaviour {

	private Toggle hammerToggle;
	private Toggle keyToggle;

	void Start () {
		hammerToggle = GameObject.Find ("hammerToggle").GetComponent<Toggle> ();
		keyToggle = GameObject.Find ("keyToggle").GetComponent<Toggle> ();

		hammerToggle.isOn = Alice.hasHammer;
		keyToggle.isOn = Alice.hasKey;

		if (Alice.foundKey) {
			GameObject.Find ("Key Text").GetComponent<Text> ().color = new Color (3.0f / 255.0f, 244.0f / 255.0f, 0.0f);
			keyToggle.interactable = true;
		}
	}

	public void ToggleHammer () {
		if (hammerToggle.isOn) {
			Alice.hasHammer = true;
		} else {
			Alice.hasHammer = false;
		}
	}

	public void ToggleKey () {
		if (keyToggle.isOn) {
			Alice.hasKey = true;
		} else {
			Alice.hasKey = false;
		}
	}
}
