using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jDown;
    bool isJump;
    public int JumpForce = 15;

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
    }

    void GetInput()
    {
        jDown = Input.GetButtonDown("Jump");
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isJump = true;
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
