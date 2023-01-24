using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("!!");
        Destroy(other.gameObject);
    }
}
