using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTerminal : MonoBehaviour, Interactable {

    public GameObject sprite;

    public string quitScene;

	public static bool canOpen = true;

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
            Filesystem.quitScene = quitScene;
            SceneManager.LoadScene("Terminal");
        }
    }

    public void PlayerEntry()
    {
        sprite.SetActive(true);
    }

    public void PlayerExit()
    {
        sprite.SetActive(false);
    }
}
