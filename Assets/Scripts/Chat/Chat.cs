using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chat : MonoBehaviour {

	public int maxLineCount = 12;
	public float delay = 1f;

	private Text pastText;
	private InputField inputField;
	private GameObject window;
	private static string text;
	private static int lineCount;
	private static int step = -1;
	private static bool stepStarted = false;
	private float lineSize = 0.3f;
	private static bool canType;
	private static bool lookingForSecretResponse = false;

	void Awake () {
		pastText = GameObject.Find ("Past Text").GetComponent<Text> ();
		pastText.supportRichText = true;
		pastText.text = text;
		inputField = GetComponentInChildren<InputField> ();
		window = GameObject.Find ("Chat Window");
	}

	void Start () {
		CloseChat.Disable ();
		ReFocus ();
		if (step < 0) {
			step++;
		}
	}

	void OnDestroy () {
		text = pastText.text;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) && canType) {
			string userInput = inputField.text;
			pastText.text = string.Concat (pastText.text, "<color=blue><b>You: </b></color>", "<color=blue>" + userInput + "</color>");
			NewLine ();
			canType = false;
			step++;
			stepStarted = false;
			if (lookingForSecretResponse && userInput.Equals ("Fuck you")) {
				lookingForSecretResponse = false;
				StartCoroutine (WhiteRabbit4 ());
			}
		}

		if (!stepStarted) {
			switch (step) {
			case 0:
				stepStarted = true;
				StartCoroutine (WhiteRabbit0 ());
				break;
			case 1:
				stepStarted = true;
				StartCoroutine (WhiteRabbit1 ());
				break;
			case 2:
				stepStarted = true;
				StartCoroutine (WhiteRabbit2 ());
				break;
			case 3:
				stepStarted = true;
				StartCoroutine (WhiteRabbit3 ());
				break;
			default:
				canType = true;
				CloseChat.Enable ();
				break;
			}
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

	private void WhiteRabbitSpeak (string text, bool withName) {
		if (withName) {
			pastText.text = string.Concat (pastText.text, "<color=red><b>White Rabbit:</b> </color>", "<color=red>" + text + "</color>");
		} else {
			pastText.text = string.Concat (pastText.text, "  ", "<color=red>" + text + "</color>");
		}
		pastText.text = string.Concat (pastText.text, "\n");
		lineCount++;
		if (lineCount >= maxLineCount) {
			Scroll ();
		}
	}

	IEnumerator WhiteRabbit0 () {
		canType = false;
		WhiteRabbitSpeak ("Hi Alice.", true);
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("What a pleasure to meet you (:", false);
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("Thanks to your incompetence, I", false);
		WhiteRabbitSpeak ("have managed to burrow my", false);
		WhiteRabbitSpeak ("way into your servers. ", false);
		canType = true;
	}

	IEnumerator WhiteRabbit1 () {
		canType = false;
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("Well, if you will", true);
		WhiteRabbitSpeak ("excuse me, I've got some", false);
		WhiteRabbitSpeak ("work to do.", false);
		yield return new WaitForSeconds (1.5f*delay);
		WhiteRabbitSpeak ("Lots of money to be", false);
		WhiteRabbitSpeak ("made today with all these", false);
		WhiteRabbitSpeak ("data on your servers.", false);
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("Trololololo", false);
		canType = true;
	}

	IEnumerator WhiteRabbit2 () {
		canType = false;
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("This is an", true);
		WhiteRabbitSpeak ("automated reply.", false);
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("I'm sorry, I can't come to", false);
		WhiteRabbitSpeak ("the keyboard right now because", false);
		WhiteRabbitSpeak ("I'm too busy talking to your", false);
		WhiteRabbitSpeak ("servers!", false);
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("If you need to reach me,", false);
		WhiteRabbitSpeak ("have fun and good luck?!?!", false);
		WhiteRabbitSpeak ("Trolololololo", false);
		canType = true;
	}

	IEnumerator WhiteRabbit3 () {
		canType = false;
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("Time is of the", true);
		WhiteRabbitSpeak ("essence. I can't talk", false);
		WhiteRabbitSpeak ("much. Bye bye!", false);
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("I can't think of how to", false);
		WhiteRabbitSpeak ("thank you enough! You can try", false);
		WhiteRabbitSpeak ("to trace me down, but you", false);
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("couldn't find me even if", false);
		WhiteRabbitSpeak ("you tried!", false);
		canType = true;
		lookingForSecretResponse = true;
		CloseChat.Enable ();
		AliceDialogue.Advance ();
	}

	IEnumerator WhiteRabbit4 () {
		canType = false;
		yield return new WaitForSeconds (delay);
		WhiteRabbitSpeak ("Lololol fuck u", true);
		WhiteRabbitSpeak ("l0s3r", false);
		canType = true;
	}
}
