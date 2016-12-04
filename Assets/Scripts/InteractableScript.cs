using UnityEngine;
using System.Collections;

/**
*Classe abstraite pour le comportement des objet avec lesquel le joueur peut interagir
*@Interact : comportement de chacun des different objet lorsque l'on interagit avec lui (doit être implementee pour chaque objet "interactable")
**/
public abstract class InteractableScript : MonoBehaviour {
	public abstract void Interact();	
}
