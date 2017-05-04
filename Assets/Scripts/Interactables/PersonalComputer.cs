using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonalComputer : MonoBehaviour, Interactable {

    public GameObject sprite;

	public static bool canOpen = true;

	public Sprite myIcon;

	private static bool hasStarted = false;

	private string myName = "Personal Computer";

	void Start () {
		string[] lines = {"You've got mail!"};
		if (!hasStarted) {
			Speech.Instance.Speak (lines, myName, 115.0f, DisableTerminalAccess, myIcon);
		}
	}

    public void Interact()
    {
        if (canOpen)
        {
            PlayerEntry();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (sprite.activeSelf))
        {
            Speech.Instance.StopSpeaking();
            hasStarted = true;
            SceneManager.LoadScene("Chat");
        }
    }

    private void DisableTerminalAccess () {
		OpenTerminal.canOpen = false;
	}

    public void PlayerEntry ()
    {
        sprite.SetActive(true);
    }

    public void PlayerExit ()
    {
        sprite.SetActive(false);
    }
}
