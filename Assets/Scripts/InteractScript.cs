using UnityEngine;
using System.Collections;

//README : Script a accrocher en enfant de la camera principale sur le joueur. Toutes les interractions avec l'environnement sont a tester a partir d'ici.
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
                    interactWith(hit.collider.gameObject);
					//hit.collider.transform.parent.GetComponent<InteractableScript>().Interact();
				}
			}
		}
	}

    void interactWith(GameObject obj)
    {
        GameObject o = obj;
        var script = o.GetComponent<InteractableScript>();
        if (script != null)
        {
            script.Interact();
            return;
        }

        if (obj.transform.parent == null)
            return;
        o = obj.transform.parent.gameObject;

        script = o.GetComponent<InteractableScript>();
        if (script != null)
        {
            script.Interact();
            return;
        }
        script = o.GetComponentInChildren<InteractableScript>();
        if (script != null)
            script.Interact();
    }
}
