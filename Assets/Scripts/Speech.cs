using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour {

	public static Speech Instance;
	public Vector3 offset;
	public float padding;

	private Text text;
	private Image image;
	private bool waitingForDismiss;
	private string[] currentDialogue;
	private int currentDialogueIndex;
	private Transform currentCharacter;

	void Awake () {
		Instance = this;
		text = GetComponentInChildren<Text> ();
		text.enabled = false;
		image = GetComponentInChildren<Image> ();
		image.enabled = false;
		waitingForDismiss = false;
	}

	void Update () {
		if (waitingForDismiss) {
			if (Input.GetMouseButtonDown (0)) {
				currentDialogueIndex++;
				if (currentDialogueIndex >= currentDialogue.Length) {
					StopSpeaking ();
				} else {
					SpeakLine ();
				}
			}

			text.transform.position = Camera.main.WorldToScreenPoint (currentCharacter.position) + offset;
			image.transform.position = text.transform.position;
			image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, text.rectTransform.rect.width + padding);
		}
	}

	public void Speak (string[] dialogue, Transform character) {
		currentDialogue = dialogue;
		currentDialogueIndex = 0;
		currentCharacter = character;
		//AliceMovement.DisableMovement ();
		SpeakLine ();
	}

	private void SpeakLine () {
		Debug.Log ("here");
		text.text = currentDialogue[currentDialogueIndex];
		text.transform.position = Camera.main.WorldToScreenPoint (currentCharacter.position) + offset;
		text.enabled = true;
		image.transform.position = text.transform.position;
		image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, text.rectTransform.rect.width + padding);
		image.enabled = true;
		waitingForDismiss = true;
	}

	private void StopSpeaking () {
		text.enabled = false;
		image.enabled = false;
		//AliceMovement.EnableMovement ();
	}
		
}
