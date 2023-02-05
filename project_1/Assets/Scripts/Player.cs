using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jDown;
    bool MoveRight;
    bool isJump;
    bool isMove;
    public int JumpForce = 15;
    public int MoveForce = 15;

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
        MoveRight = Input.GetButtonDown("Horizontal");
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
        if (MoveRight && !isJump)
        {
            Debug.Log("move horizontal");
            //rigid.AddForce(Vector3.right * MoveForce, ForceMode.Impulse);
            //isJump = true;
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
