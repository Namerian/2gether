using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
    public float M_MovementSpeed = 1f;
    public float M_RotationSpeed = 1f;
    public float M_TimerSpeed = 0.5f;

    public AudioClip[] M_footsteps;

    private Transform m_charTransform;
    private CharacterController m_charController;
    private AudioSource m_audioSource;
    private float m_timerValue = 0;

    //==================================================================
    // Use this for initialization
    void Start()
    {
        m_charTransform = this.transform;
        m_charController = GetComponent<CharacterController>();
        m_audioSource = GetComponent<AudioSource>();
    }

    //==================================================================
    // Update is called once per frame
    void Update()
    {
        if (!G.Sys.gameManager.IsGameRunning)
        {
            return;
        }

        //**************************************************************
        //Movement
        Vector3 position = this.transform.position;
        float horizontal = Input.GetAxis("Controller_1_X_Axis");
        float vertical = Input.GetAxis("Controller_1_Y_Axis");

        Vector3 movement = new Vector3(horizontal, 0f, -vertical);      //creating a vector with the joystick values, x-axis for left/right and z-axis for forward/back
        movement = this.transform.rotation * movement;                  //rotating the movement vector in the direction the player is currently facing
        movement.Normalize();
        movement *= /*Time.deltaTime **/ M_MovementSpeed;                   //multiplying the movement vector with the current deltaTime and the player speed
                                                                            //m_charController.Move (movement);								//the Move method of the CharacterController Component has a good collision detection
        m_charController.SimpleMove(movement);

        if (position != this.transform.position)
        {
            m_timerValue -= Time.deltaTime;
            if (m_timerValue <= 0)
            {
                m_audioSource.clip = M_footsteps[Random.Range(0, M_footsteps.Length)];
                m_audioSource.Play();
                m_timerValue = M_TimerSpeed;
            }

        }
        else m_timerValue = 0;

        //**************************************************************
        //Rotation
        float rotation = Input.GetAxis("Controller_1_4th_Axis");

        if (rotation < 0f)
        {
            m_charTransform.Rotate(this.transform.up, -1 * M_RotationSpeed * Time.deltaTime);
        }
        else if (rotation > 0f)
        {
            m_charTransform.Rotate(this.transform.up, M_RotationSpeed * Time.deltaTime);
        }
    }
}
