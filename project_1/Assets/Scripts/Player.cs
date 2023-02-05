using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jDown;
    bool MoveRight;
    bool MoveLeft;
    bool isJump;
    bool isMove;
    public int JumpForce = 15;
    public float MoveForce = 3;
    public float MoveJumpForce = 1;
    public float friction = 0.5f;
    Rigidbody rigid;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Jump();
        MoveHorizontal();
    }

    void GetInput()
    {
        jDown = Input.GetButtonDown("Jump");
        MoveRight = Input.GetKeyDown("right");
        MoveLeft = Input.GetKeyDown("left");
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isJump = true;
        }
    }

    void MoveHorizontal()
    {
        
            if (MoveRight && !isJump && !isMove)
            {
                if (transform.position.x <= 3f)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(MoveForce, MoveJumpForce, 0),  /*Time.deltaTime **/ friction);
                //rigid.AddForce(Vector3.right * MoveForce, ForceMode.);
                //isMove= true;
                    
                }
                
            }
            if (MoveLeft && !isJump && !isMove)
            {
                if (transform.position.x >= -3f)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(-MoveForce, MoveJumpForce, 0), /*Time.deltaTime **/ friction);
                //rigid.AddForce(Vector3.right * MoveForce, ForceMode.);
                //isMove = true;
                }
            }
         

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
}
