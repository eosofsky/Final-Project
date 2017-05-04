using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour {

	public delegate void Callback ();

	public static Speech Instance;
	public float hPadding;
	public float vPadding;

	private Text name; 
	private Text text;
	private Text arrows;
	private Image speakerIcon;
	private Image image;
	private bool waitingForDismiss;
	private string[] currentDialogue;
	private string currentSpeaker;
	private Sprite currentIcon;
	private int currentDialogueIndex;
	private float offset;
	private Callback callback;

	void Awake () {
		Instance = this;
		name = GetComponentsInChildren<Text> ()[0];
		name.enabled = false;
		text = GetComponentsInChildren<Text> ()[1];
		text.enabled = false;
		arrows = GetComponentsInChildren<Text> ()[2];
		arrows.enabled = false;
		image = GetComponentsInChildren<Image> ()[0];
		image.enabled = false;
		speakerIcon = GetComponentsInChildren<Image> () [1];
		speakerIcon.enabled = false;
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

			//text.transform.position = Camera.main.WorldToScreenPoint (currentCharacter.position) + new Vector3 (0.0f, offset, 0.0f);
			//image.transform.position = text.transform.position;
			//image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, text.rectTransform.rect.width + hPadding);
			//image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, text.rectTransform.rect.height + vPadding);
		}
	}

	public void Speak (string[] dialogue, string character, float newOffset, Callback myCallback, Sprite icon) {
		Doorway.canPass = false;
		OpenTerminal.canOpen = false;
		OpenBusUI.canOpen = false;
		GameObject pc = GameObject.Find ("Personal Computer");
		//if (pc && character != pc.transform) {
		PersonalComputer.canOpen = false;
		//}
		currentDialogue = dialogue;
		currentDialogueIndex = 0;
		currentSpeaker = character;
		currentIcon = icon;
		offset = newOffset;
		callback = myCallback;
		//AliceMovement.DisableMovement ();
		SpeakLine ();
	}

	private void SpeakLine () {
		name.text = currentSpeaker + ":";
		name.enabled = true;
		text.text = currentDialogue[currentDialogueIndex];
		//text.transform.position = Camera.main.WorldToScreenPoint (/*currentCharacter.position*/) + new Vector3 (0.0f, offset, 0.0f);
		text.enabled = true;
		//image.transform.position = text.transform.position;
		//image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, text.rectTransform.rect.width + hPadding);
		//image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, text.rectTransform.rect.height + vPadding);
		image.enabled = true;
		arrows.enabled = true;
		speakerIcon.sprite = currentIcon;
		speakerIcon.enabled = true;
		waitingForDismiss = true;
	}

	public void StopSpeaking () {
		name.enabled = false;
		text.enabled = false;
		image.enabled = false;
		speakerIcon.enabled = false;
		arrows.enabled = false;
		waitingForDismiss = false;
		Doorway.canPass = true;
		OpenTerminal.canOpen = true;
		OpenBusUI.canOpen = true;
		PersonalComputer.canOpen = true;
		if (callback != null) {
			callback ();
		}
		//AliceMovement.EnableMovement ();
	}
		
}
