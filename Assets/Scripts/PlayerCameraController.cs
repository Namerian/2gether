using UnityEngine;
using System.Collections;

public class PlayerCameraController : MonoBehaviour
{
    public float M_maxCameraAngle = 20f;

    public Vector3 M_centerPos = new Vector3(0f, 1.15f, -0.5f);
    public Vector3 M_leftPos = new Vector3(-0.5f, 1f, -0.25f);
    public Vector3 M_rightPos = new Vector3(0.5f, 1f, -0.25f);

    public float M_transitionTime = 0.5f;

    private enum CameraPosition
    {
        left,center,right
    }

    private CameraPosition m_currentCameraPosition;
    private bool m_isTransitionning;
    private float m_transitionValue;
    private Vector3 m_viewRotation;

    // Use this for initialization
    void Start()
    {
        m_currentCameraPosition = CameraPosition.center;
        this.transform.localPosition = M_centerPos;

        m_isTransitionning = false;
        m_transitionValue = 0f;
        m_viewRotation = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Controller_2_4th_Axis");
        float vertical = Input.GetAxis("Controller_2_5th_Axis");

        m_viewRotation.y = Mathf.Clamp(m_viewRotation.y + horizontal, -M_maxCameraAngle, M_maxCameraAngle);
        m_viewRotation.x = Mathf.Clamp(m_viewRotation.x + vertical, -M_maxCameraAngle, M_maxCameraAngle);

        this.transform.localRotation = Quaternion.Euler(m_viewRotation);
    }
}
