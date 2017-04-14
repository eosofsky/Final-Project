using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseChat : MonoBehaviour {

	public void Close () {
		SceneManager.LoadScene ("Level1");
	}
}
