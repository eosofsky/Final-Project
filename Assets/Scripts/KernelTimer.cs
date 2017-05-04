using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KernelTimer : MonoBehaviour {

    private static float time = 0.0f;
    private static float limit = 10.0f;
    private static bool timerStart = true;

	void Awake () {
		ShowKernelMem (Alice.hatActive);
	}

	void Update () {
		if (Alice.hatActive && timerStart) {
            time = 0.0f;
            timerStart = false;
			ShowKernelMem(true);
        } else if (Alice.hatActive) {
            time += Time.deltaTime;
        }

        if (time >= limit) {
			ResetHat ();
        }
	}

	public void ResetHat () {
		time = 0.0f;
		ShowKernelMem(false);
		Alice.RemoveHat ();
		timerStart = true;
	}

	private void ShowKernelMem (bool show) {
		GameObject[] kernelMem = GameObject.FindGameObjectsWithTag ("KernelWorld");
		for (int c = 0; c < kernelMem.Length; c++) {
			Debug.Log (kernelMem[c].name);
			SpriteRenderer sr = kernelMem [c].gameObject.GetComponent<SpriteRenderer> ();
			if (sr) {
				sr.enabled = show;
			}
			Collider collider = kernelMem [c].gameObject.GetComponent<Collider> ();
			if (collider) {
				collider.enabled = show;
			}
        }
		GameObject[] kernelBounds = GameObject.FindGameObjectsWithTag ("KernelBoundary");
		for (int c = 0; c < kernelBounds.Length; c++) {
			kernelBounds[c].gameObject.GetComponent<Collider> ().enabled = !show;
		}
    }
}
