using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KernelTimer : MonoBehaviour {

    private int numChildren;
    private float time;
    private float limit;
    private bool timerStart;

	// Use this for initialization
	void Start () {
        numChildren = transform.childCount;
        timerStart = true;
        limit = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Alice.hatActive && timerStart)
        {
            time = 0.0f;
            timerStart = false;
            Toggle();
        }
        else if (Alice.hatActive)
        {
            time += Time.deltaTime;
        }

        if (time >= limit)
        {
            time = 0.0f;
            Toggle();
            Alice.hatActive = false;
            timerStart = true;
        }
	}

    void Toggle()
    {
        for (int c = 0; c < numChildren; c++)
        {
            var child = transform.GetChild(c);
            child.gameObject.SetActive(!(child.gameObject.activeSelf));
        }
    }
}
