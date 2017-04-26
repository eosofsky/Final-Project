using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonalComputer : MonoBehaviour, Interactable {

	public void Interact () {
		SceneManager.LoadScene ("Chat");
	}

}
