using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePath : MonoBehaviour {

    public GameObject start;
    public GameObject end;

    // Update is called once per frame
    void Update () {
        var position = transform.position;
        var endPos = end.transform.position;
		if (position.x < endPos.x + 2.25f)
        {
            transform.position = start.gameObject.transform.position;
            return;
        }
        
        var nextPosition = Vector3.Lerp(position, endPos, 0.05f);
        transform.position = nextPosition;
	}
}
