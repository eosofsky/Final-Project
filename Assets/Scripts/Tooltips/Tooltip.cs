using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

	public static Tooltip Instance;
	public Vector3 offset;
	public float padding;

	private Text text;
	private Image image;

	void Awake () {
		Instance = this;
		text = GetComponentInChildren<Text> ();
		text.enabled = false;
		image = GetComponentInChildren<Image> ();
		image.enabled = false;
	}

	public void ShowTooltip (string newText) {
		text.text = newText;
		transform.position = Input.mousePosition + offset;
		text.enabled = true;
		image.transform.position = transform.position;
		image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, text.rectTransform.rect.width + padding);
		image.enabled = true;
	}

	public void HideTooltip () {
		text.enabled = false;
		image.enabled = false;
	}
		
}
