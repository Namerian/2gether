using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoorScript : InteractableScript
{
	public bool _isOpen = false;
	public bool _isLocked = false;
	public bool _canBeOpened = true;
	public float _doorOpenAngle = 90f;
	public float _doorCloseAngle = 0;
	public float _doorOpeningSpeed = 2;
	public AudioClip _soundOpening = null;
	public AudioClip _soundLocked = null;

	private AudioSource _audioSourceComponent;

	private bool _isMoving = false;

	void Start ()
	{
		_audioSourceComponent = GetComponent<AudioSource> ();
	}

	public override void Interact ()
	{
		//Debug.Log ("DoorScript: Interact: called");

        if(_isMoving || !_canBeOpened)
        {
            return;
        }

		if (!_isOpen) {
			if (!_isLocked) {
				MoveDoor ();
			} else if (_isLocked && G.Sys.gameManager.playerHasKey && _canBeOpened) {
				MoveDoor ();
				G.Sys.gameManager.playerHasKey = false;
                _isLocked = false;
			} else {
				if (_soundLocked != null) {
					_audioSourceComponent.clip = _soundLocked;
					_audioSourceComponent.Play ();
				}
			}
		} else {
			MoveDoor ();
		}
	}

	protected void MoveDoor ()
	{
		if (_isMoving) {
			return;
		}

		Vector3 target = this.transform.localEulerAngles;
		if (_isOpen) {
			_isOpen = false;
			target = new Vector3 (0, _doorCloseAngle, 0);
		} else if (!_isOpen) {
			_isOpen = true;
			target = new Vector3 (0, _doorOpenAngle, 0);
		}

		this.transform.DOLocalRotate (target, _doorOpeningSpeed).OnComplete (TweenComplete);
		_isMoving = true;

		if (_soundOpening != null) {
			_audioSourceComponent.clip = _soundOpening;
			_audioSourceComponent.Play ();
		}
	}

	private void TweenComplete ()
	{
		_isMoving = false;
	}
}
