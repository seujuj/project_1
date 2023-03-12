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
    bool isCrossRoad;
    public bool isDead;
    public int JumpForce = 15;
    public float MoveForce = 3;
    public float MoveDelay = 1;
    public float MoveJumpForce = 1;
    public float MoveForwardSpeed = 10;
    public float TurnSpeed = 50;
    //public float friction = 0.5f;  
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
        isCrossRoad = false;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            transform.Translate(Vector3.forward * MoveForwardSpeed * Time.deltaTime, Space.Self);
        }
        GetInput();
        Jump();
        MoveHorizontal();
        DoAttack();
    }

    void GetInput()
    {
        if(isDead == false)
        {
            aDown = Input.GetButtonDown("Attack");
            jDown = Input.GetButtonDown("Jump");
            MoveRight = Input.GetKey("right");
            MoveLeft = Input.GetKey("left");
        }
        
    }

    void Jump()
    {
        if (jDown && !isJump )
        {
            rigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
            //isMove = false;
        }
        
    }

    void MoveHorizontal()
    {
        
            if (MoveRight && /*!isJump &&*/ isMove && !isCrossRoad)
            {
                //rigid.AddForce(new Vector3(MoveForce, MoveJumpForce, 0), ForceMode.Impulse); //ÈûÁÖ´Â ¹æ½Ä
                //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(3,0,0) , ref vel, friction);
                transform.Translate(Vector3.right * MoveForce * Time.deltaTime,Space.Self);

                //if (isCrossRoad)
                //{
                //    transform.Rotate(new Vector3(0, 90f, 0) * 30 * Time.deltaTime);
                //    Invoke("DoMove()", 1f);
                //}
                //rigid.AddForce(Vector3.right * MoveForce, ForceMode.);
                //anim.SetTrigger("moveRight");
                isMove = true;
                //Invoke("DoMove", MoveDelay);
                
                
            }
            if (MoveLeft && /*!isJump &&*/ isMove && !isCrossRoad)
            {
                
                //rigid.AddForce(new Vector3(-MoveForce, MoveJumpForce, 0), ForceMode.Impulse);
                //rigid.AddForce(Vector3.right * MoveForce, ForceMode.);
                //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-3, 0, 0), ref vel, friction);
                transform.Translate(Vector3.left * MoveForce * Time.deltaTime, Space.Self);

                //if(isCrossRoad)
                //{
                //    transform.Rotate(new Vector3(0, -90f, 0) * 30 * Time.deltaTime);
                //    Invoke("DoMove()", 1f);
                //}
                    
                //anim.SetTrigger("moveLeft");
                isMove = true;
                //Invoke("DoMove", MoveDelay);
                
            }

            
    }

    void DoMove()
    {
        isMove = true;
        isCrossRoad = false;
    }

    void AttackOut()
    {
        isAttack = false;
        Sword.SetActive(false);
    }

    void DoAttack()
    {
        if (aDown && !isAttack && !isJump)
        {
            Debug.Log("attack ani~~");
            isAttack = true;
            Sword.SetActive(true);
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
            isMove = true;
            //Debug.Log("landing");

        }

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "deadZone")
        {
            
            //isDead = true;
            //isJump = true;
            //Background _speed = GameObject.Find("Main").GetComponent<Background>();
            //_speed.speed = 0;
            anim.SetTrigger("die");


        }
        if (collision.gameObject.tag == "TurnRightZone")
        {
            Debug.Log("turnright");
            isCrossRoad = true;
            anim.SetTrigger("doTurnRight");
            transform.Rotate(new Vector3(0, 90f, 0) * TurnSpeed * Time.deltaTime);
            Invoke("DoMove", 1f);
            GameObject[] crossroad = GameObject.FindGameObjectsWithTag("CrossRoad");
            if(crossroad !=null)
            {
                for (int i = 0; i < crossroad.Length; ++i)
                {
                    Debug.Log("turn rightt crossroad");
                    GameObject crossTransform = crossroad[i];
                    crossTransform.transform.Rotate(new Vector3(0, 90f, 0) *TurnSpeed* Time.deltaTime);
                }
            }
            
                
            
        }
        if (collision.gameObject.tag == "TurnLeftZone")
        {
            Debug.Log("turn left");
            isCrossRoad = true;
            anim.SetTrigger("doTurnLeftt");
            transform.Rotate(new Vector3(0, -90f, 0) * TurnSpeed * Time.deltaTime);
            Invoke("DoMove", 1f);
            GameObject[] crossroad = GameObject.FindGameObjectsWithTag("CrossRoad");
            if (crossroad != null)
            {
                for (int i = 0; i < crossroad.Length; ++i)
                {
                    Debug.Log("turn left crossroad");
                    GameObject crossTransform = crossroad[i];
                    crossTransform.transform.Rotate(new Vector3(0, -90f, 0) * TurnSpeed * Time.deltaTime);
                }
            }
                

        }
    }
    

    
}
