using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KernelTimer : MonoBehaviour {

    private static float time = 0.0f;
    private static float limit = 10.0f;
    private static bool timerStart = true;
	
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
			Alice.RemoveHat ();
            timerStart = true;
        }
	}

    void Toggle () {
		GameObject[] kernelMem = GameObject.FindGameObjectsWithTag ("KernelWorld");
		for (int c = 0; c < kernelMem.Length; c++) {
			kernelMem[c].gameObject.SetActive(!(kernelMem[c].activeSelf));
        }
    }
}
