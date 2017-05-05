using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour, Interactable {
  
    public GameObject sprite;

	public static bool canCollect = false;

	private static bool collected = false;
	private static SpriteRenderer sr;
	private static Collider collider;

	void Awake () {
		if (collected) {
			Destroy (gameObject);
			Destroy (sprite);
		} else {
			sr = GetComponent<SpriteRenderer> ();
			collider = GetComponent<Collider> ();
			sr.enabled = canCollect;
			collider.enabled = canCollect;
		}
	}

    public void Interact()
    {
        PlayerEntry();
    }

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.E) && (sprite.activeSelf) && canCollect)
        {
            Alice.hasHat = true;
			Destroy (sprite);
			collected = true;
			canCollect = false;
			Destroy(gameObject);
        }
    }

	public void Activate () {
		StartCoroutine (activate ());
	}

	IEnumerator activate () {
		yield return new WaitForSeconds (0.5f);
		sr.enabled = true;
		collider.enabled = true;
		canCollect = true;
	}

	//public static void Deactivate () {
	//	GetComponent<SpriteRenderer> ().enabled = false;
	//	GetComponent<Collider> ().enabled = false;
	//	canCollect = false;
	//}

    public void PlayerEntry()
    {
        sprite.SetActive(true);
    }

    public void PlayerExit()
    {
        sprite.SetActive(false);
    }
}
