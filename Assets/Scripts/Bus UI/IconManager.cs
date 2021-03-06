﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {

	public Sprite Icon1;
	public Sprite Icon2;
	public Sprite IconBoss;

	void Awake () {
		bool cameFromBossRoom = false;
		if (SourceManager.oldScene.Equals ("Bus Exterior 1") || SourceManager.oldScene.Equals ("Bus Exterior 2")) {
			Image image = GameObject.Find ("Bus UI 1").GetComponent<Image> ();
			image.sprite = Icon1;
		} else if (SourceManager.oldScene.Equals ("Bus 2 Exterior 1") || SourceManager.oldScene.Equals ("Bus 2 Exterior 2")) {
			Image image = GameObject.Find ("Bus UI 2").GetComponent<Image> ();
			image.sprite = Icon2;
		} else if (SourceManager.oldScene.Equals ("Boss Room")) {
			Image image = GameObject.Find ("Bus UI 3").GetComponent<Image> ();
			image.sprite = IconBoss;
			cameFromBossRoom = true;
		}

		if (!Alice.hatActive && !cameFromBossRoom) {
			GameObject button3 = GameObject.Find ("Bus UI 3");
			button3.GetComponentInChildren<Button> ().onClick = null;
			button3.GetComponent<Image> ().enabled = false;
		}
	}
}
