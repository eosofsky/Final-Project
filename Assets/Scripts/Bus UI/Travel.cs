using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Travel : MonoBehaviour {

	public void GoToTerminalA () {
		SourceManager.oldScene = "Bus Terminal";
		SceneManager.LoadScene ("Bus Station 1");
	}

	public void GoToTerminalB () {
		SourceManager.oldScene = "Bus Terminal";
		SceneManager.LoadScene ("Bus Station 2");
	}

	public void GoToBossRoom () {
		SourceManager.oldScene = "Bus Terminal";
		SceneManager.LoadScene ("Boss Room");
	}

}
