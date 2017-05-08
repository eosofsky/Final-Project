using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    public GameObject[] track;

    private GameObject nextStop;
    private int index;
    private bool onTrack;
	private static bool hasStarted = false;

	private bool shouldPan = true;

	// Use this for initialization
	void Start () {
		if (hasStarted) {
			shouldPan = false;
			return;
		}
		AliceMovement.DisableMovement ();
		if (track.Length > 1) {
			nextStop = track [1];
			index = 1;
			onTrack = true;
		} else {
			AliceMovement.EnableMovement ();
			onTrack = false;
		}
		hasStarted = true;
	}

    private bool AlmostEquals(Vector3 one, Vector3 two)
    {
        var oneX = one.x;
        var oneY = one.y;
        var oneZ = one.z;
        var twoX = two.x;
        var twoY = two.y;
        var twoZ = two.z;

        if (Mathf.Abs(oneX - twoX) <= 0.5f && Mathf.Abs(oneY - twoY) <= 0.5f && Mathf.Abs(oneZ - twoZ) <= 0.5f)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update () {
		if (!shouldPan) {
			return;
		}
		if (onTrack)
        {
            var targetLocation = nextStop.transform.position;
            var nextLocation = Vector3.Lerp(Camera.main.transform.position, targetLocation, 0.01f);

            Camera.main.transform.position = nextLocation;

            if (AlmostEquals(targetLocation, Camera.main.transform.position))
            {
                index++;
                if (index > track.Length)
                {
                    onTrack = false;
                    AliceMovement.EnableMovement();
                    return;
                }

                if (index < track.Length)
                {
                    nextStop = track[index];
                }
                else
                {
                    nextStop = track[0];
                }
            }
        }
	}
}
