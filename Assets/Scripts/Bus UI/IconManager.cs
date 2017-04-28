using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {

	public Sprite Icon1;
	public Sprite Icon2;
	public Sprite IconBoss;

	void Awake () {
		Image image = GameObject.Find ("Bus UI 1").GetComponent<Image> ();
		if (SourceManager.oldScene.Equals ("Bus Exterior 1") || SourceManager.oldScene.Equals ("Bus Exterior 2")) {
			image.sprite = Icon1;
		} else if (SourceManager.oldScene.Equals ("Bus 2 Exterior 1") || SourceManager.oldScene.Equals ("Bus 2 Exterior 2")) {
			image.sprite = Icon2;
		}

		SourceManager.oldScene = "Terminal";
	}
}
