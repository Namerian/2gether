using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SafeLockBehaviour : InteractableScript
{
	private const float _TURN_ANGLE = 60.0f;

	public int _combination = 1;
	public int[] _positions = { 0, 1, 2, 3, 4, 5 };
	public AudioClip _soundHit = null;
	public AudioClip _soundMiss = null;

	private int _currentPositionIndex = 0;
	private AudioSource _audioSourceComponent = null;
	private bool _isLocked = true;

	// Use this for initialization
	void Start ()
	{
		_audioSourceComponent = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public override void Interact ()
	{
		Debug.Log ("SafeLockBehaviour:Interact:called!");

		/*Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform == this.transform) {
				Vector3 localHitPoint = this.transform.InverseTransformPoint (hit.point);

				Debug.Log ("test: worldPoint=" + hit.point + " localPoint=" + localHitPoint);
			}
		}*/

		//update current position
		_currentPositionIndex += 1;

		if (_currentPositionIndex == _positions.Length) {
			_currentPositionIndex = 0;
		}

		bool correctPosition = (_positions [_currentPositionIndex] == _combination);

		if (correctPosition && _isLocked) {
			_isLocked = false;
			Debug.Log ("SafeLockBehaviour:Interact:safe unlocked!");
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
		localAngles.x -= _TURN_ANGLE;
		this.transform.DOLocalRotate (localAngles, 0.5f);
	}

	public bool GetIsLocked ()
	{
		return _isLocked;
	}
}
