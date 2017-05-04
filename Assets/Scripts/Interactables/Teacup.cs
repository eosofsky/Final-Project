using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacup : MonoBehaviour, Interactable {

    public GameObject sprite;

	public Sprite intactSprite;
	public Sprite brokenSprite;
    public Vector3[] positions;
    public int index;

    private Vector3 finish;
	private SpriteRenderer spriteRenderer;
	private bool broken;

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = intactSprite;
		broken = false;
        finish = positions[index];
	}

    private bool AlmostEquals(Vector3 one, Vector3 two)
    {
        var oneX = one.x;
        var oneY = one.y;
        var oneZ = one.z;
        var twoX = two.x;
        var twoY = two.y;
        var twoZ = two.z;

        if (Mathf.Abs(oneX-twoX) <= 0.1f && Mathf.Abs(oneY - twoY) <= 0.1f && Mathf.Abs(oneZ - twoZ) <= 0.1f)
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        var start = transform.position;
        if (AlmostEquals(start, finish))
        {
            index++;
            finish = positions[index % 8];
        }

        var destination = Vector3.Lerp(start, finish, 0.025f);
        transform.position = destination;
    }

    public void Interact () {
		if (!broken && Alice.hasHammer) {
			Alice.Hammer ();
			spriteRenderer.sprite = brokenSprite;
			broken = true;
			Destroy (gameObject.GetComponent<Collider> ());
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
