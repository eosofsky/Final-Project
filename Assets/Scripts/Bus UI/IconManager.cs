using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {

	public Sprite Icon1;
	public Sprite Icon2;
	public Sprite IconBoss;

	void Awake () {
		if (SourceManager.oldScene.Equals ("Bus Exterior 1") || SourceManager.oldScene.Equals ("Bus Exterior 2")) {
			Image image1 = GameObject.Find ("Bus UI 1").GetComponent<Image> ();
			image1.sprite = Icon1;
		}
	}
}
