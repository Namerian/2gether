using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class PianoScript : MonoBehaviour {
	public List<int> notesSuite;
	List<int> currentNotes = new List<int>();

	public void addNote(int noteId) {
		currentNotes.Add(noteId);
		if(this.isSequenceValid()) {
			if(notesSuite.Count == currentNotes.Count) {
				//Do something : challenge solved
				Debug.Log("Sequence Achieved");
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
}
