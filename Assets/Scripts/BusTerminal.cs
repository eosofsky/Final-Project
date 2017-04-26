using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusTerminal : MonoBehaviour {

	public Transform position;

	void Start () {
		GameObject Alice = GameObject.Find ("Alice");
		Alice.transform.position = position.position;
	}
}
