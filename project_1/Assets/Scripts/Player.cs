using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jDown;
    bool aDown;
    bool MoveRight;
    bool MoveLeft;
    bool isJump;
    bool isMove;
    bool isAttack;
    bool isDead;
    public int JumpForce = 15;
    public float MoveForce = 3;
    public float MoveDelay = 1;
    public float MoveJumpForce = 1;
    public float friction = 0.5f;
    Rigidbody rigid;
    Animator anim;
    public GameObject targetposition;
    public GameObject Sword;
    Vector3 vel = Vector3.zero;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        isDead = false;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Jump();
        MoveHorizontal();
        DoAttack();
    }

    void GetInput()
    {
        aDown = Input.GetButtonDown("Attack");
        jDown = Input.GetButtonDown("Jump");
        MoveRight = Input.GetKey("right");
        MoveLeft = Input.GetKey("left");
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
                //rigid.AddForce(new Vector3(MoveForce, MoveJumpForce, 0), ForceMode.Impulse); //ÈûÁÖ´Â ¹æ½Ä
                //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(3,0,0) , ref vel, friction);
                transform.Translate(Vector3.right * MoveForce * Time.deltaTime);
                //rigid.AddForce(Vector3.right * MoveForce, ForceMode.);
                //anim.SetTrigger("moveRight");
                //isMove = true;
                //Invoke("DoMove", MoveDelay);
                }
                
            }
            if (MoveLeft && !isJump && !isMove)
            {
                if (transform.position.x >= -3f)
                {
                //rigid.AddForce(new Vector3(-MoveForce, MoveJumpForce, 0), ForceMode.Impulse);
                //rigid.AddForce(Vector3.right * MoveForce, ForceMode.);
                //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-3, 0, 0), ref vel, friction);
                transform.Translate(Vector3.left * MoveForce * Time.deltaTime);
                //anim.SetTrigger("moveLeft");
                //isMove = true;
                //Invoke("DoMove", MoveDelay);
                }
            }

            
    }

    void DoMove()
    {
        isMove = false;
    }

    void AttackOut()
    {
        isAttack = false;
        Sword.active = false;
    }

    void DoAttack()
    {
        if (aDown && !isAttack && !isJump)
        {
            Debug.Log("attack ani~~");
            isAttack = true;
            Sword.active = true;
            //anim.SetBool("isAttack", true);
            anim.SetTrigger("doAttack");
            Invoke("AttackOut", 0.3f);
        }

    }

    void OnCollisionEnter(Collision collision)
    
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
            //Debug.Log("landing");

        }



    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "deadZone")
        {
            Debug.Log("dead!");
            isDead = true;
            isJump = true;
            Background _speed = GameObject.Find("Main").GetComponent<Background>();
            _speed.speed = 0;
            anim.SetTrigger("die");


        }
    }
    

    
}
