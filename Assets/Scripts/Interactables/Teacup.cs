using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacup : MonoBehaviour, Interactable {

	public Sprite intactSprite;
	public Sprite brokenSprite;

	private SpriteRenderer spriteRenderer;
	private bool broken;

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = intactSprite;
		broken = false;
	}

	public void Interact () {
		if (!broken && Alice.hasHammer) {
			spriteRenderer.sprite = brokenSprite;
			broken = true;
			Destroy (gameObject.GetComponent<Collider> ());
		}
	}
}
