﻿using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour {
	public float interactDistance = 5;

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Mouse0)) 
		{
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, interactDistance)) 
			{
				if(hit.collider.CompareTag("Interactable")) 
				{
					hit.collider.transform.parent.GetComponent<InteractableScript>().Interact();
				}
			}
		}
	}
}
