using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
	public float M_MovementSpeed = 1f;
	public float M_RotationSpeed = 1f;

    private Transform m_charTransform;
	private CharacterController m_charController;

	//==================================================================
	// Use this for initialization
	void Start ()
	{
        m_charTransform = this.transform;
        m_charController = m_charTransform.GetComponent<CharacterController>();
	}

	//==================================================================
	// Update is called once per frame
	void Update ()
	{
		//**************************************************************
		//Movement
		float horizontal = Input.GetAxis ("Controller_1_X_Axis");
		float vertical = Input.GetAxis ("Controller_1_Y_Axis");

		Vector3 movement = new Vector3 (horizontal, 0f, -vertical);		//creating a vector with the joystick values, x-axis for left/right and z-axis for forward/back
		movement = this.transform.rotation * movement;					//rotating the movement vector in the direction the player is currently facing
		movement.Normalize ();											
		movement *= /*Time.deltaTime **/ M_MovementSpeed;                   //multiplying the movement vector with the current deltaTime and the player speed
        //m_charController.Move (movement);								//the Move method of the CharacterController Component has a good collision detection
        m_charController.SimpleMove(movement);

		//**************************************************************
		//Rotation
		float rotation = Input.GetAxis ("Controller_1_4th_Axis");
        
		if (rotation < 0f) {
			m_charTransform.Rotate (this.transform.up, -1 * M_RotationSpeed * Time.deltaTime);
		} else if (rotation > 0f) {
			m_charTransform.Rotate (this.transform.up, M_RotationSpeed * Time.deltaTime);
		}
	}
}
