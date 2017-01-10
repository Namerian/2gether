using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class PianoScript : MonoBehaviour {
	public List<int> notesSuite;
    public List<GameObject> doors;
	List<int> currentNotes = new List<int>();
    AudioSource unlockSource;

    void Start()
    {
        unlockSource = GetComponent<AudioSource>();
    }

	public void addNote(int noteId) {
		currentNotes.Add(noteId);
		if(this.isSequenceValid()) {
			if(notesSuite.Count == currentNotes.Count) {
                //Do something : challenge solved
                openDoors();
				currentNotes.Clear();
			}
		} else {
			currentNotes.Clear();
			//Add some "failure" feedback
		}
	}

	bool isSequenceValid() {
		bool sequenceValidity = true;
		for(int i=0; i<currentNotes.Count; i++) {
			if(currentNotes.ElementAt(i) != notesSuite.ElementAt(i))
				sequenceValidity = false;
		}
		return sequenceValidity;
	}

    void openDoors()
    {
        unlockSource.Play();

        foreach(var door in doors)
        {
            var script = door.GetComponent<DoorScript>();
            if (script == null)
                continue;
            script._canBeOpened = true;
            script._isLocked = false;
            if(!script._isOpen)
                script.Interact();
        }
    }
}
