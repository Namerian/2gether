using UnityEngine;
using System.Collections;

public class NoteScript : InteractableScript {
	public int noteId;
	AudioSource note;

	void Start()
    {
        note = GetComponent<AudioSource>();
    }

	public override void Interact()
    {
        note.Play();
		if (this.transform.parent == null)
            return;
        GameObject o = this.transform.parent.gameObject;

        var script = o.GetComponent<PianoScript>();
        if (script != null)
        {
            script.addNote(noteId);
        }
    }

}
