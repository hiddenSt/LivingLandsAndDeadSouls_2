using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    public float playerSpeed;
    private Vector2 moveVelocity;
    private Rigidbody2D _rigidBody;
    public float speedMove;
    private Animator animator;
    private CharacterController characterController;
    private Vector3 moveVector;
    public MobileController mContr;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mContr = GameObject.Find("JoystickBG").GetComponent<MobileController>();
    }

    private void Update()
    {
        moveVector = Vector3.zero;
        moveVector.x = mContr.Horizontal();
        moveVector.y = mContr.Vertical();
        Debug.Log("Pos x: "+moveVector.x);
        Debug.Log("Pos y: "+moveVector.y);
        if (moveVector.x>0.9)
        {
            animator.Play("Move_right");
        }
        else if (moveVector.x<-0.9)
        {
            animator.Play("Move_left");
        }
        else 
        {
            if (moveVector.y>0)
            {
                animator.Play("Move_back");
            }
            else if (moveVector.y<0)
            {
                animator.Play("Move_face");
            }
            else
            {
                animator.Play("Idle_right");
            }
        }
        Vector2 moveInput = new Vector2(moveVector.x, moveVector.y);
        moveVelocity = moveInput * playerSpeed;

        
    }

    public void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position+moveVelocity);
    }
}
