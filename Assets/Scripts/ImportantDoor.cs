using UnityEngine;
using System.Collections;

public class ImportantDoor : DoorScript
{
	public enum OpenDoorEvent
	{
		Victory,
		Defeat
	}

	public OpenDoorEvent _onOpenDoor;

	private GameManager _gameManager;
	//private AudioSource _audio = null;

	// Use this for initialization
	void Start ()
	{
		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		/*var audios = GetComponents<AudioSource> ();
		if (audios.Length > 2)
			_audio = audios [2];*/
	}

	public override void Interact ()
	{
		//Debug.Log ("ImportantDoor: ChangeDoorState: called");

		bool wasDoorOpen = base._isOpen;

		base.Interact ();

		/*if (_audio != null) {
			_audio.Play ();
		}*/
		
		if (!wasDoorOpen && base._isOpen) {
			switch (_onOpenDoor) {
			case OpenDoorEvent.Defeat:
				_gameManager.OnDoorEvent (_onOpenDoor);
				break;
			case OpenDoorEvent.Victory:
				_gameManager.OnDoorEvent (_onOpenDoor);
				break;
			}
		}
	}
}
