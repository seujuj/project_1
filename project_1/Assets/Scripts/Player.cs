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
    Animator anim;
    public GameObject targetposition;
    Vector3 vel = Vector3.zero;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
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
        if (jDown && !isJump && !isMove)
        {
            rigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void MoveHorizontal()
    {
        
            if (MoveRight && !isJump && !isMove )
            {
                if (transform.position.x <= 3f)
                {
                rigid.AddForce(new Vector3(MoveForce, MoveJumpForce, 0), ForceMode.Impulse);
                //transform.position = Vector3.SmoothDamp(transform.position, targetposition.transform.position , ref vel, friction);
                //rigid.AddForce(Vector3.right * MoveForce, ForceMode.);
                anim.SetTrigger("moveRight");
                isMove = true;
                Invoke("DoMove", 1f);
                }
                
            }
            if (MoveLeft && !isJump && !isMove)
            {
                if (transform.position.x >= -3f)
                {
                rigid.AddForce(new Vector3(-MoveForce, MoveJumpForce, 0), ForceMode.Impulse);
                //rigid.AddForce(Vector3.right * MoveForce, ForceMode.);
                anim.SetTrigger("moveLeft");
                isMove = true;
                Invoke("DoMove", 1f);
            }
            }
    }

    void DoMove()
    {
        isMove = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
}
