using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chat : MonoBehaviour {

	public int maxLineCount = 12;

	private Text pastText;
	private InputField inputField;
	private GameObject window;
	private static string text;
	private static int lineCount;
	private static bool hasLoaded = false;
	private float lineSize = 0.3f;

	void Awake () {
		pastText = GameObject.Find ("Past Text").GetComponent<Text> ();
		pastText.text = text;
		inputField = GetComponentInChildren<InputField> ();
		window = GameObject.Find ("Chat Window");
	}

	void Start () {
		ReFocus ();
	}

	void OnDestroy () {
		text = pastText.text;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			pastText.text = string.Concat (pastText.text, "You: ", inputField.text);
			NewLine ();
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			WhiteRabbitSpeak ("I am late!");
		}
	}

	private void NewLine () {
		pastText.text = string.Concat (pastText.text, "\n");
		lineCount++;
		if (lineCount >= maxLineCount) {
			Scroll ();
		}
		inputField.text = "";
	}
		
	private void Scroll () {
		int endOfFirstLine = pastText.text.IndexOf ("\n");
		pastText.text = pastText.text.Substring (endOfFirstLine + 1);
		pastText.transform.Translate (new Vector3 (0.0f, lineSize));
	}

	public void ReFocus () {
		inputField.ActivateInputField ();
	}

	private void WhiteRabbitSpeak (string text) {
		pastText.text = string.Concat (pastText.text, "White Rabbit: ", text);
		NewLine ();
	}
}
