using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : MonoBehaviour {

	public static bool hasHammer = false;
	public static bool hasHat = false;
    public static bool hatActive = false;
	public static bool foundExtinguisher = false;
	public Sprite digitalAlice;
	public Sprite physicalAlice;
	public bool physical;
	public static int numCoreFiles = 0;
	public static bool foundKey = false;
	public static bool hasKey = false;

	private static SpriteRenderer spriteRender;
	private static Sprite myDigitalAlice;
	private static Sprite myPhysicalAlice;
	private bool hasMoved;
	private static bool isphysical;

	private static Animator anim;

	void Awake () {
		spriteRender = GetComponent<SpriteRenderer> ();
		myDigitalAlice = digitalAlice;
		myPhysicalAlice = physicalAlice;
		hasMoved = false;
		anim = GetComponent<Animator> ();
		if (hatActive && !physical && anim) {
			anim.SetBool ("HasHat", true);
		}
		isphysical = physical;
	}

	void Start () {
		spriteRender.sprite = physical ? myPhysicalAlice : myDigitalAlice;
	}

	void Update () {
		if (!hasMoved && (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0)) {
			hasMoved = true;
		}

		if (Input.GetKeyDown(KeyCode.H) && hasHat && !hatActive && !physical)
        {
            hatActive = true;
			if (anim) {
				anim.SetTrigger ("WearHat");
			}
        }
	}

	public static void RemoveHat () {
		if (!isphysical && anim && hatActive) {
			anim.SetBool ("HasHat", false);
			anim.SetTrigger ("RemoveHat");
			hatActive = false;
		}
	}

	public static void Hammer () {
		if (anim) {
			anim.SetTrigger ("Hammer");
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

    private void OnTriggerExit(Collider collider)
    {
        Interactable interactable = collider.gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactable.PlayerExit();
        }
    }

    public static void ExtinguishFire () {
		anim.SetTrigger ("Extinguish");
	}
		
}
