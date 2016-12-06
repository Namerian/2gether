using UnityEngine;
using System.Collections;
using System;

public class CondemnedDoor : InteractableScript {
    private AudioSource _audio;

    void Start () {
        _audio = GetComponent<AudioSource>();
	}

    public override void Interact()
    {
        _audio.Play();
    }
}
