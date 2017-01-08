using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SafeLockBehaviour : InteractableScript
{
	public int _numOfPositions = 6;
	public int _key = 4;
	public int _startingPosition = 0;

	public AudioClip _soundHit = null;
	public AudioClip _soundMiss = null;

	private AudioSource _audioSourceComponent = null;

	private float _turnAngle = 0;
	private int _currentPosition = 0;
	private bool _isLocked = true;
	private bool _isTurning = false;

	//=======================================================

	void OnValidate ()
	{
		_numOfPositions = Mathf.Clamp (_numOfPositions, 0, 9);
		_key = Mathf.Clamp (_key, 0, _numOfPositions);
	}

	// Use this for initialization
	void Start ()
	{
		_audioSourceComponent = GetComponent<AudioSource> ();

		_turnAngle = 360 / _numOfPositions;
		_currentPosition = _startingPosition;
	}

	public override void Interact ()
	{
		//Debug.Log ("SafeLockBehaviour:Interact:called!");

		if (!_isLocked || _isTurning) {
			return;
		}

		/*Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform == this.transform) {
				Vector3 localHitPoint = this.transform.InverseTransformPoint (hit.point);

				Debug.Log ("test: worldPoint=" + hit.point + " localPoint=" + localHitPoint);
			}
		}*/

		//update current position
		_currentPosition++;

		if (_currentPosition == _numOfPositions) {
			_currentPosition = 0;
		}

		bool correctPosition = (_currentPosition == _key);

		if (correctPosition && _isLocked) {
			_isLocked = false;
			//Debug.Log ("SafeLockBehaviour:Interact:safe unlocked!");
		}

		//play feedback sound
		if (correctPosition && _soundHit != null) {
			_audioSourceComponent.clip = _soundHit;
			_audioSourceComponent.Play ();
		} else if (!correctPosition && _soundMiss != null) {
			_audioSourceComponent.clip = _soundMiss;
			_audioSourceComponent.Play ();
		}

		//rotate button
		Vector3 localAngles = this.transform.localEulerAngles;
		localAngles.x -= _turnAngle;
		this.transform.DOLocalRotate (localAngles, 0.5f).OnComplete (TweenComplete);
		_isTurning = true;
	}

	public bool GetIsLocked ()
	{
		return _isLocked;
	}

	private void TweenComplete ()
	{
		_isTurning = false;
	}
}
