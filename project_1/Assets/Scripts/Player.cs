using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jDown;

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
        Jump();   
    }

    void GetInput()
    {
        jDown = Input.GetButtonDown("Jump");
    }

    void Jump()
    {
        Debug.Log("justJump");
        if (jDown)
        {
            Debug.Log("asdfijh");
            //rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
        }
    }
}