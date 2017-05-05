using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Interactable {

	public GameObject sprite;

	void Awake () {
		if (Alice.foundKey) {
			Destroy (gameObject);
			Destroy (sprite);
		}
	}

	void Update () {
		if (sprite.activeSelf && Input.GetKeyDown (KeyCode.E)) {
			Alice.foundKey = true;
			Alice.hasKey = true;
			Destroy (gameObject);
			Destroy (sprite);
		}
	}

    public void Interact () {
		PlayerEntry ();
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
