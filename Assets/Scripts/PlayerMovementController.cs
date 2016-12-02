using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
    public float M_MovementSpeed = 1f;
    public float M_RotationSpeed = 1f;

    private CharacterController m_charController;

    // Use this for initialization
    void Start()
    {
        m_charController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float horizontal = Input.GetAxis("Controller_1_X_Axis");
        float vertical = Input.GetAxis("Controller_1_Y_Axis");

        Vector3 movement = new Vector3(horizontal, 0f, -vertical);
        movement = this.transform.rotation * movement;
        movement.Normalize();
        movement *= Time.deltaTime * M_MovementSpeed;
        m_charController.Move(movement);

        //Rotation
        float rotation =  Input.GetAxis("Controller_1_4th_Axis");
        
        if(rotation < 0f)
        {
            this.transform.Rotate(this.transform.up, -1 * M_RotationSpeed * Time.deltaTime);
        }
        else if(rotation > 0f)
        {
            this.transform.Rotate(this.transform.up, M_RotationSpeed * Time.deltaTime);
        }
    }
}
