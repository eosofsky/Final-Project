using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour, Interactable {
  
    public GameObject sprite;

    public void Interact()
    {
        PlayerEntry();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (sprite.activeSelf))
        {
            Alice.hasHat = true;
            Destroy(gameObject);
        }
    }

    public void PlayerEntry()
    {
        sprite.SetActive(true);
    }

    public void PlayerExit()
    {
        sprite.SetActive(false);
    }
}
