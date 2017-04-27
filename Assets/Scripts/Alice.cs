using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : MonoBehaviour {

	public static bool hasHammer = false;
	public static bool hasHat;
    public static bool hatActive = false;
	public Sprite digitalAlice;
	public Sprite physicalAlice;
	public bool physical;

	private static SpriteRenderer spriteRender;
	private static Sprite myDigitalAlice;
	private static Sprite myPhysicalAlice;
	private bool hasMoved;

	void Awake () {
		spriteRender = GetComponent<SpriteRenderer> ();
		myDigitalAlice = digitalAlice;
		myPhysicalAlice = physicalAlice;
		hasMoved = false;
	}

	void Start () {
		//spriteRender.sprite = SwitchWorlds.physical ? myPhysicalAlice : myDigitalAlice;
		spriteRender.sprite = physical ? myPhysicalAlice : myDigitalAlice;
	}

	void Update () {
		if (!hasMoved && (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0)) {
			hasMoved = true;
		}

        if (Input.GetKeyDown(KeyCode.H))
        {
            hatActive = true;
        }
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		if (!hasMoved) {
			return;
		}

		Interactable interactable = hit.collider.gameObject.GetComponent<Interactable> ();
		if (interactable != null) {
			interactable.Interact ();
		}
	}

	void OnTriggerEnter (Collider collider) {
		if (!hasMoved) {
			return;
		}

		Interactable interactable = collider.gameObject.GetComponent<Interactable> ();
		if (interactable != null) {
			interactable.Interact ();
		}
	}

	public static void ExtinguishFire () {
		//RandomFiles.HideFiles ();
		Mail.Activate ();
		BusStation.busIsFixed = true;
	}
		
}
