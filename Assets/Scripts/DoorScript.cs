using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoorScript : InteractableScript
{
	public bool isOpen = false;
	public bool isLocked = false;
	public float doorOpenAngle = 90f;
	public float doorCloseAngle = 0;
	public float doorOpeningSpeed = 2;
	public AudioClip _soundOpening = null;
	public AudioClip _soundLocked = null;

	private GameManager _gameManager;
	private AudioSource _audioSourceComponent;

	private bool _isMoving = false;

	void Start ()
	{
		this._gameManager = G.Sys.gameManager;
		_audioSourceComponent = GetComponent<AudioSource> ();
	}

	/**
	*	Toggle l'ouverture d'une porte si elle n'est pas verrouillee
	*	Ajouter 2 audio source en enfant de la porte. 1er : Ouverture et fermeture de la porte 2nd : feedback sonnore pour une porte fermee.
	*	@player : le transform du player pour tester s'il possède la clef
	**/
	public virtual void ChangeDoorState ()
	{
		//Debug.Log ("DoorScript: ChangeDoorState: called");

		if (_isMoving) {
			return;
		}

		if (!isOpen) {
			if (!isLocked) {
				MoveDoor ();
			} else if (isLocked && G.Sys.gameManager.playerHasKey) {
				MoveDoor ();
				G.Sys.gameManager.playerHasKey = false;
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

	public override void Interact ()
	{
		this.ChangeDoorState ();
	}

	/*void Update()
    {
        if (isOpen)
        {
            Quaternion targetRotation1 = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation1, doorOpeningSpeed * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, doorOpeningSpeed * Time.deltaTime);
        }
    }*/

	protected void MoveDoor ()
	{
		if (_isMoving) {
			return;
		}

		Vector3 target = this.transform.localEulerAngles;
		if (isOpen) {
			isOpen = false;
			target = new Vector3 (0, doorCloseAngle, 0);
		} else if (!isOpen) {
			isOpen = true;
			target = new Vector3 (0, doorOpenAngle, 0);
		}

		this.transform.DOLocalRotate (target, doorOpeningSpeed).OnComplete (TweenComplete);
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
