using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour {

	public Vector3[] positions;

	void Start () {
		GameObject Alice = GameObject.Find ("Alice");

		switch (SourceManager.oldScene) {
		case "Terminal":
			Alice.transform.position = positions [0];
			break;
		case "Bus Station":
			Alice.transform.position = positions [1];
			break;
		case "Room 1":
			Alice.transform.position = positions [2];
			break;
		case "Bus Interior 1":
			Alice.transform.position = positions [3];
			break;
		case "Bus Interior 2":
			Alice.transform.position = positions [4];
			break;
		case "Bus Exterior 1":
			Alice.transform.position = positions [5];
			break;
		case "Bus Exterior 2":
			Alice.transform.position = positions [6];
			break;
		default:
			break;
		}
	}
}
