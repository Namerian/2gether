﻿using UnityEngine;
using System.Collections;

public class DoorScript : InteractableScript {
	public bool isOpen = false;
	public bool isLocked = false;
	public float doorOpenAngle = 90f;
	public float doorCloseAngle = 0;
	public float doorOpeningSpeed = 2;

	/**
	*	Toggle l'ouverture d'une porte si elle n'est pas verrouillee
	*	Ajouter 2 audio source en enfant de la porte. 1er : Ouverture et fermeture de la porte 2nd : feedback sonnore pour une porte fermee.
	*	@player : le transform du player pour tester s'il possède la clef
	*/
	public void ChangeDoorState() {
		var audios = GetComponents<AudioSource>();
        if(audios.Length > 0)
        {
            var doorMovingSound = audios[0];
            //var doorLockedSound = audios[1];
            if (!isLocked /*|| player.hasKey()*/) //
            {
                isOpen = !isOpen;
                doorMovingSound.Play();
            }
            else
            {
                //doorLockedSound.Play();
            }
        }
	}

	public override void Interact() 
	{
		this.ChangeDoorState();
	}

	void Update () 
	{
		if(isOpen) {
			Quaternion targetRotation1 = Quaternion.Euler(0, doorOpenAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation1, doorOpeningSpeed * Time.deltaTime);
		} else {
			Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, doorOpeningSpeed * Time.deltaTime);		
		}	
	}
}