using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour {

	public delegate void Callback ();

	public static Speech Instance;
	public float hPadding;
	public float vPadding;

	private Text text;
	private Image image;
	private bool waitingForDismiss;
	private string[] currentDialogue;
	private int currentDialogueIndex;
	private Transform currentCharacter;
	private float offset;
	private Callback callback;

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

			text.transform.position = Camera.main.WorldToScreenPoint (currentCharacter.position) + new Vector3 (0.0f, offset, 0.0f);
			image.transform.position = text.transform.position;
			image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, text.rectTransform.rect.width + hPadding);
			image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, text.rectTransform.rect.height + vPadding);
		}
	}

	public void Speak (string[] dialogue, Transform character, float newOffset, Callback myCallback) {
		Doorway.canPass = false;
		OpenTerminal.canOpen = false;
		OpenBusUI.canOpen = false;
		currentDialogue = dialogue;
		currentDialogueIndex = 0;
		currentCharacter = character;
		offset = newOffset;
		callback = myCallback;
		//AliceMovement.DisableMovement ();
		SpeakLine ();
	}

	private void SpeakLine () {
		text.text = currentDialogue[currentDialogueIndex];
		text.transform.position = Camera.main.WorldToScreenPoint (currentCharacter.position) + new Vector3 (0.0f, offset, 0.0f);
		text.enabled = true;
		image.transform.position = text.transform.position;
		image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, text.rectTransform.rect.width + hPadding);
		image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, text.rectTransform.rect.height + vPadding);
		image.enabled = true;
		waitingForDismiss = true;
	}

	public void StopSpeaking () {
		text.enabled = false;
		image.enabled = false;
		waitingForDismiss = false;
		Doorway.canPass = true;
		OpenTerminal.canOpen = true;
		OpenBusUI.canOpen = true;
		if (callback != null) {
			callback ();
		}
		//AliceMovement.EnableMovement ();
	}
		
}
