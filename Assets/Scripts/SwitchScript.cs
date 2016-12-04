using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SwitchScript : InteractableScript
{
    public List<GameObject> lights;
    public bool state = false;

    private List<LightScript> _lightsScripts = new List<LightScript>();

    public override void Interact()
    {
        transform.Rotate(0, 0, 180);
        state = !state;

        foreach (var l in _lightsScripts)
        {
            l.state = state;
        }
    }

    void Start ()
    {
	    foreach(var l in lights)
        {
            if (l == null)
                continue;
            var script = l.GetComponent<LightScript>();
            if (script != null)
                _lightsScripts.Add(script);
        }

        foreach(var l in _lightsScripts)
        {
            l.state = state;
        }
	}
	
	void Update ()
    {
	
	}
}
