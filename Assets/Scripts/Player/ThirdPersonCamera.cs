using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    //Holds data reelated to player XZ location.
    private PlayerInput playerInput;
    private Vector2 inputVector = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>(); 
    }

    public void OnCamera(InputValue value)
    {

    }

    
    // Update is called once per frame
    void Update()
    {
        //rotate orientation 
        Vector3 viewDir = player.position - new Vector3(player.position.x, player.position.y, player.position.z);
        orientation.forward = viewDir.normalized;

        //roate player object
        float horizontalInput = inputVector.x;
        float verticalInput = inputVector.y;
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);

        
    }
}
