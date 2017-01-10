using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerCameraController : MonoBehaviour
{
	public float M_maxCameraAngle = 20f;
	public float M_cameraRotationSpeed = 2f;

	public Vector3 M_centerPos = new Vector3 (0f, 1.15f, -0.5f);
	public Vector3 M_leftPos = new Vector3 (-0.5f, 1f, -0.25f);
	public Vector3 M_rightPos = new Vector3 (0.5f, 1f, -0.25f);

	public float M_transitionTime = 0.5f;

	private enum CameraPosition
	{
		left,
		center,
		right
	}

	private Camera m_camera;

	//private CameraPosition m_currentCameraPosition;
	//private bool m_isTransitionning;
	//private float m_transitionValue;

	private Vector3 m_viewRotation;

	//==================================================================
	// Use this for initialization
	void Start ()
	{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_camera = this.GetComponent<Camera> ();

		//m_currentCameraPosition = CameraPosition.center;
		//this.transform.localPosition = M_centerPos;

		//m_isTransitionning = false;
		//m_transitionValue = 0f;

		m_viewRotation = this.transform.localEulerAngles;
	}

	//==================================================================
	// Update is called once per frame
	void Update ()
	{
		//**************************************************************
		//Rotation

		m_viewRotation.x += -Input.GetAxis ("Mouse_Y") * M_cameraRotationSpeed * Time.deltaTime;
		m_viewRotation.x = Mathf.Clamp (m_viewRotation.x, -M_maxCameraAngle, M_maxCameraAngle);

		m_viewRotation.y += Input.GetAxis ("Mouse_X") * M_cameraRotationSpeed * Time.deltaTime;
		m_viewRotation.y = Mathf.Clamp (m_viewRotation.y, -M_maxCameraAngle, M_maxCameraAngle);

		transform.localEulerAngles = m_viewRotation;


		//**************************************************************
		//Movement
		/*float movement = Input.GetAxis ("Controller_2_X_Axis");
		m_transitionValue += movement * Time.deltaTime;

		if (!m_isTransitionning) {
			
			if (m_transitionValue >= 1f) {	//start transition to the left
				m_transitionValue = 0f;
				m_isTransitionning = true;

				if (m_currentCameraPosition == CameraPosition.right) {
					m_currentCameraPosition = CameraPosition.center;
					this.transform.DOLocalMove (M_centerPos, 1f).OnComplete (OnTweenEnd);
				} else if (m_currentCameraPosition == CameraPosition.center) {
					m_currentCameraPosition = CameraPosition.left;
					this.transform.DOLocalMove (M_leftPos, 1f).OnComplete (OnTweenEnd);
				}
			} else if (m_transitionValue <= -1f) {	//start transition to the right
				m_transitionValue = 0f;
				m_isTransitionning = true;

				if (m_currentCameraPosition == CameraPosition.left) {
					m_currentCameraPosition = CameraPosition.center;
					this.transform.DOLocalMove (M_centerPos, 1f).OnComplete (OnTweenEnd);
				} else if (m_currentCameraPosition == CameraPosition.center) {
					m_currentCameraPosition = CameraPosition.right;
					this.transform.DOLocalMove (M_rightPos, 1f).OnComplete (OnTweenEnd);
				}
			}
		}*/
	}

	//==================================================================
	/*void OnTweenEnd ()
	{
		m_isTransitionning = false;
	}*/
}
