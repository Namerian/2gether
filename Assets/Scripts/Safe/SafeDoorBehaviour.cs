using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SafeDoorBehaviour : InteractableScript
{
	public AudioClip _soundOpening = null;

	private SafeLockBehaviour _lock = null;
	private bool _isOpen = false;
	private AudioSource _audioSourceComponent = null;

	// Use this for initialization
	void Start ()
	{
		_lock = this.transform.GetComponentInChildren<SafeLockBehaviour> ();
		_audioSourceComponent = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public override void Interact ()
	{
		if (_lock.GetIsLocked () || _isOpen) {
			return;
		}

		Vector3 localRotation = this.transform.localEulerAngles;
		localRotation.y -= 90f;
		this.transform.DOLocalRotate (localRotation, 3);

		if (_soundOpening != null) {
			_audioSourceComponent.clip = _soundOpening;
			_audioSourceComponent.Play ();
		}
	}
}
