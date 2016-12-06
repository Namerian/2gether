using UnityEngine;
using System.Collections;
using System;

public class KeyScript : InteractableScript
{
    private GameManager _gameManager;
    private AudioSource _audio;

    
    void Start ()
    {
       _gameManager = G.Sys.gameManager;
        _audio = GetComponent<AudioSource>();
	}

    public override void Interact()
    {
        Debug.Log("KeyScript: Interact: called");

        _audio.Play();

        if(_gameManager != null) {
            _gameManager.playerHasKey = true;
        }
        //Destroy(gameObject);
        transform.position = new Vector3(0, -10000, 0);
    }
}
