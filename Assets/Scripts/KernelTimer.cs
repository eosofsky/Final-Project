using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KernelTimer : MonoBehaviour {

    private static float time = 0.0f;
    private static float limit = 10.0f;
    private static float watches = 20.0f;
    private static bool timerStart = true;
    private static int watchIndex = 0;
    public GameObject tick;

    private Image image;

    private Sprite[] Stopwatches;


	void Awake ()
    {
        Stopwatches = Resources.LoadAll<Sprite>("Stopwatch");
        image = GetComponentInChildren<Image>();
        ShowKernelMem (Alice.hatActive);
        tick = GameObject.Find("tick_tock");
	}

	void Update () {
		if (Alice.hatActive && timerStart) {
            tick.GetComponent<AudioSource>().volume = 1.0f;
            time = 0.0f;
            timerStart = false;
			ShowKernelMem(true);
            image.enabled = true;
        } else if (Alice.hatActive) {
            time += Time.deltaTime;
        }

        if (time >= limit) {
			ResetHat ();
        }
        AnimStopwatch();
    }

    private Sprite FindFrame(string title)
    {
        foreach (var frame in Stopwatches)
        {
            if (frame.name.Equals(title))
                return frame;
        }
        return Stopwatches[0];
    }

    private void AnimStopwatch()
    {
        var increment = limit / watches;
        if (Alice.hatActive && time >= (increment*watchIndex))
        {
            if (watchIndex >= watches)
            {
                return;
            }
            var spriteName = string.Format("Frame {0}", watchIndex);
            image.sprite = FindFrame(spriteName);
            watchIndex++;
        }
    }

	public void ResetHat () {
        tick.GetComponent<AudioSource>().volume = 0.0f;
		time = 0.0f;
        watchIndex = 0;
        ShowKernelMem(false);
		Alice.RemoveHat ();
		timerStart = true;
        image.enabled = false;
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
