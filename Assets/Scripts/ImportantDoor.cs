using UnityEngine;
using System.Collections;

public class ImportantDoor : DoorScript
{
	public enum OpenDoorEvent
	{
		Victory,
		Defeat
	}

	public OpenDoorEvent M_onOpenDoor;

	private GameManager m_gameManager;
    private AudioSource m_audio = null;

	// Use this for initialization
	void Start ()
	{
		m_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        var audios =  GetComponents<AudioSource>();
        if (audios.Length > 2)
            m_audio = audios[2];
	}

	public override void ChangeDoorState ()
	{
        Debug.Log("ImportantDoor: ChangeDoorState: called");

		bool wasDoorOpen = base.isOpen;

		base.ChangeDoorState ();
        if(m_audio != null)
            m_audio.Play();
		if (!wasDoorOpen && base.isOpen) {
			switch (M_onOpenDoor) {
			case OpenDoorEvent.Defeat:
				m_gameManager.OnDoorEvent (M_onOpenDoor);
				break;
			case OpenDoorEvent.Victory:
				m_gameManager.OnDoorEvent (M_onOpenDoor);
				break;
			}
		}
	}
}
