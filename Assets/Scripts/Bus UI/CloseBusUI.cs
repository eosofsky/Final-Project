using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseBusUI : MonoBehaviour {

	public void Close () {
		SceneManager.LoadScene ("Bus Interior");
	}
}
