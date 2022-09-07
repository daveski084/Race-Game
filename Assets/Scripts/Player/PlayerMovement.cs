using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    // private float gravityValue = -9.81f;
    private PlayerInput playerInput;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>(); 
    }

    public void OnMove(InputValue input)
    {
        inputVector = input.Get<Vector2>();
    }

    void Update()
    {
        Vector3 move = new Vector3(inputVector.x, 0, inputVector.y);

        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}


        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}


        //If check to get rid of that annoying warning that pops up for having no input. 
        //if (move != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.LookRotation(move);
        //}

        transform.position +=  move * playerSpeed * Time.deltaTime;
        //transform.Translate(move * playerSpeed * Time.deltaTime, Space.World); 

    }

}
