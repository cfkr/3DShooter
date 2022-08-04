using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    [SerializeField]
    private float forwardMoveSpeed = 100;
    [SerializeField]
    private float backwardMoveSpeed = 45;
    [SerializeField]
    private float turnSpeed=5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);
        transform.Rotate(Vector3.up, horizontal * turnSpeed*Time.deltaTime);

            if(vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? forwardMoveSpeed : backwardMoveSpeed; // ileri ve geri hýzý ayarlamak için if saykýlý kullandýk.
            characterController.SimpleMove(transform.forward* moveSpeedToUse * Time.deltaTime*vertical);

        }
    }
        
        
    
}
