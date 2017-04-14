using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : MonoBehaviour {

	public static bool hasHammer = false;
	public static bool hasHat;
	public Sprite digitalAlice;
	public Sprite physicalAlice;

	private static SpriteRenderer spriteRender;
	private static Sprite myDigitalAlice;
	private static Sprite myPhysicalAlice;

	void Awake () {
		spriteRender = GetComponent<SpriteRenderer> ();
		myDigitalAlice = digitalAlice;
		myPhysicalAlice = physicalAlice;
	}

	void Start () {
		spriteRender.sprite = SwitchWorlds.physical ? myPhysicalAlice : myDigitalAlice;
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		Interactable interactable = hit.collider.gameObject.GetComponent<Interactable> ();
		if (interactable != null) {
			interactable.Interact ();
		}
	}
		
}
