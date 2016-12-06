using UnityEngine;
using System.Collections;
using System;

public class KeyScript : InteractableScript
{
    private GameManager _gameManager;

    
    void Start ()
    {
       this._gameManager = G.Sys.gameManager;
	}

    public override void Interact()
    {
        Debug.Log("KeyScript: Interact: called");

        if(_gameManager != null) {
            _gameManager.playerHasKey = true;
        }
        Destroy(gameObject);
    }
}
