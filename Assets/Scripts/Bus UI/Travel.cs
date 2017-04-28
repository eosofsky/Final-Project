using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Travel : MonoBehaviour {

	public void GoToTerminalA () {
		SceneManager.LoadScene ("Bus Station 1");
	}

	public void GoToTerminalB () {
		SceneManager.LoadScene ("Bus Station 2");
	}

	public void GoToBossRoom () {
		SceneManager.LoadScene ("Boss Room");
	}

}
