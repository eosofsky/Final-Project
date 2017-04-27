using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Terminal : MonoBehaviour {

	public int maxLineCount = 10;
	public string listCommand;
	public string openCommand;
	public string clearCommand;
	public string deleteCommand;
	public string quitCommand;
	public string runCommand;

	private static string text = ">>> ";
	private Text pastText;
	private InputField inputField;
	private GameObject screen;
	private static int lineCount = 0;
	private float lineSize = 80.0f;
	private static bool hasLoaded = false;
	private static Vector3 inputStartingPos;
	private static Vector3 inputPos; 
	private static Vector3 pastTextStartingPos;
	private static Vector3 pastTextPos;
	private static int numFiles;

	void Awake () {
		pastText = GameObject.Find ("Past Text").GetComponent<Text> ();
		pastText.text = text;
		inputField = GetComponentInChildren<InputField> ();
		screen = GameObject.Find ("Screen");
	}

	void Start () {
		SourceManager.oldScene = "";

		if (hasLoaded) {
			pastText.transform.position = pastTextPos;
			inputField.transform.position = inputPos;
		} else {
			numFiles = Filesystem.files.Length;
			pastTextStartingPos = pastText.transform.position;
			inputStartingPos = inputField.transform.position;
		}
		ReFocus ();
		hasLoaded = true;
	}

	void OnDestroy () {
		text = pastText.text;
		pastTextPos = pastText.transform.position;
		inputPos = inputField.transform.position;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			string input = inputField.text;
			if (input.Equals (clearCommand)) {
				Clear ();
				return;
			} else if (input.Equals (listCommand)) {
				if (numFiles != 0) {
					pastText.text = string.Concat (pastText.text, input);
					NewLine ();
				}
				for (int i = 0; i < Filesystem.files.Length; i++) {
					if (Filesystem.files [i] == null) {
						continue;
					}
					pastText.text = string.Concat (pastText.text, "  ", Filesystem.files [i]);
					if (i != Filesystem.files.Length - 1 && Filesystem.files [i + 1] != null) {
						NewLine ();
					}
				}
			} else if (Regex.IsMatch (input, string.Concat (openCommand, "  *"))) {
				pastText.text = string.Concat (pastText.text, input);
				//NewLine ();
				string filename = input.Substring (openCommand.Length + 1);
				//Debug.Log (filename);
				inputField.text = "";
				bool found = false;
				for (int i = 0; i < Filesystem.files.Length; i++) {
					if (Filesystem.files [i] != null && Filesystem.files [i].Equals (filename)) {
						if (Filesystem.canEdit [i]) {
							if (filename.Equals ("Tools.cs")) {
								SceneManager.LoadScene ("Tools");
							} else if (filename.Equals ("Walrus.cs")) {
								SceneManager.LoadScene ("Garbage Collector");
							} else {
								pastText.text = string.Concat (pastText.text, inputField.text);
								NewLine ();
								pastText.text = string.Concat (pastText.text, string.Concat ("  ERROR: Permission denied"));
							}
						} else {
							pastText.text = string.Concat (pastText.text, inputField.text);
							NewLine ();
							pastText.text = string.Concat (pastText.text, string.Concat ("  ERROR: Permission denied"));
						}
						found = true;
						break;
					}
				}
				if (!found) {
					pastText.text = string.Concat (pastText.text, inputField.text);
					NewLine ();
					pastText.text = string.Concat (pastText.text, "  ERROR: File not found");
				}
			} else if (Regex.IsMatch (input, string.Concat (deleteCommand, "  *"))) {
				string filename = input.Substring (deleteCommand.Length + 1);
				bool found = false;
				for (int i = 0; i < Filesystem.files.Length; i++) {
					if (Filesystem.files [i] != null && Filesystem.files [i].Equals (filename)) {
						pastText.text = string.Concat (pastText.text, inputField.text);
						NewLine ();
						if (Filesystem.canDelete [i]) {
							Filesystem.files [i] = null;
							pastText.text = string.Concat (pastText.text, string.Concat ("  SUCCESS: Removed ", filename));
							numFiles--;
							//if (filename.Equals ("Walrus.txt")) {
							//	WalrusManager.KillWalrus ();
							//}
						} else {
							pastText.text = string.Concat (pastText.text, string.Concat ("  ERROR: Permission denied"));
						}
						found = true;
						break;
					}
				}
				if (!found) {
					pastText.text = string.Concat (pastText.text, inputField.text);
					NewLine ();
					pastText.text = string.Concat (pastText.text, "  ERROR: File not found");
				}
			} else if (input.Equals (quitCommand)) {
				SceneManager.LoadScene (Filesystem.quitScene);
			} else if (Regex.IsMatch (input, string.Concat (runCommand, "  *"))) {
				string filename = input.Substring (runCommand.Length + 1);
				bool found = false;
				for (int i = 0; i < Filesystem.files.Length; i++) {
					if (Filesystem.files [i] != null && Filesystem.files [i].Equals (filename)) {
						if (Filesystem.canRun [i]) {
							if (filename.Equals ("Alice.exe")) {
								//SwitchWorlds.physical = false;
								Filesystem.canRun [0] = false;
								SourceManager.oldScene = SceneManager.GetActiveScene ().name;
								SceneManager.LoadScene ("Bus Station");
							} else {
								pastText.text = string.Concat (pastText.text, inputField.text);
								NewLine ();
								pastText.text = string.Concat (pastText.text, string.Concat ("  ERROR: Permission denied"));
							}
						} else {
							pastText.text = string.Concat (pastText.text, inputField.text);
							NewLine ();
							pastText.text = string.Concat (pastText.text, string.Concat ("  ERROR: Permission denied"));
						}
						found = true;
						break;
					}
				}
				if (!found) {
					pastText.text = string.Concat (pastText.text, inputField.text);
					NewLine ();
					pastText.text = string.Concat (pastText.text, "  ERROR: File not found");
				}
			} else if (input.Equals ("")) {
			} else {
				pastText.text = string.Concat (pastText.text, inputField.text);
				NewLine ();
				pastText.text = string.Concat (pastText.text, "  ERROR: Invalid command");
			}
			pastText.text = string.Concat (pastText.text, inputField.text);
			NewLine ();
			pastText.text = string.Concat (pastText.text, ">>> ");
		}
	}

	private void Clear () {
		inputField.transform.position = inputStartingPos;
		inputField.text = "";
		pastText.transform.position = pastTextStartingPos;
		pastText.text = ">>> ";
		lineCount = 0;
	}

	private void NewLine () {
		pastText.text = string.Concat (pastText.text, "\n");
		lineCount++;
		if (lineCount >= maxLineCount) {
			Scroll ();
		}
		inputField.text = "";
		inputField.transform.Translate (new Vector3 (0.0f, -lineSize, 0.0f));
	}

	private void Scroll () {
		screen.transform.Translate (new Vector3 (0.0f, lineSize));
	}

	public void ReFocus () {
		inputField.ActivateInputField ();
	}
}
