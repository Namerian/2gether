using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SwitchScript : InteractableScript
{
    public List<GameObject> lights;
    public bool state = false;

    private AudioSource _audioOpen = null;
    private AudioSource _audioClose = null;
    private List<LightScript> _lightsScripts = new List<LightScript>();

    public override void Interact()
    {
        transform.Rotate(0, 0, 180);
        state = !state;

        if (!state)
            _audioClose.Play();
        else _audioOpen.Play();

        foreach (var l in _lightsScripts)
        {
            l.state = state;
        }
    }

    void Start ()
    {
        var sources = GetComponents<AudioSource>();
        if (sources.Length > 0)
            _audioOpen = sources[0];
        if (sources.Length > 1)
            _audioClose = sources[1];

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
