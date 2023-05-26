using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    [SerializeField]
    private PlayerShooting shootingScript;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
           
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

           
            moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        
        moveDirection.y -= gravity * Time.deltaTime;

       
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "PowerUp":
            
                shootingScript.powerUp = true;
                Destroy(other.gameObject);

                break;

            case "PowerUp2":

                shootingScript.powerUp2 = true;
                Destroy(other.gameObject);

                break;

            case "PowerUp3":

                shootingScript.powerUp3 = true;
                Destroy(other.gameObject);

                break;

            case "PowerUp4":

                shootingScript.powerUp4 = true;
                Destroy(other.gameObject);

                break;

            case "PowerUp5":

                shootingScript.powerUp5 = true;
                Destroy(other.gameObject);
                
                break;
        }
    }
}




