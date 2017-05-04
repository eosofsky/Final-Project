using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Interactable {

	public GameObject sprite;

	void Awake () {
		if (Alice.foundKey) {
			Destroy (gameObject);
		}
	}

    public void Interact () {
		Alice.foundKey = true;
		Alice.hasKey = true;
		Destroy (gameObject);
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
