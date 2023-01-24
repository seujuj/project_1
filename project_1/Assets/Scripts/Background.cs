using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject _stageA;
    public GameObject _stageB;
    //public GameObject _stageC;
    public float speed;
    //public int startIndex;
    //public int endIndex;
    //public Transform[] _stage1;

    public float viewDist = 10;
    private bool isFar = false;

    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 curPos = _stageA.transform.position;
        Vector3 nextPos = Vector3.back * speed * Time.deltaTime;
        //if(_stageA != null && _stageB != null )//&& _stageC != null)
        //{
            _stageA.transform.position += nextPos;
            _stageB.transform.position += nextPos;
            //_stageC.transform.position += nextPos;
        //}
        
        //멀리 배경 생성
        if (_stageA != null && _stageA.transform.position.z < -5 && isFar == false)
        {
            GameObject stageloop1 = Instantiate(_stageB, new Vector3(0, 0,  viewDist ) , transform.rotation);
            if (_stageB != null && _stageB.transform.position.z < -50)
                DestroyImmediate(_stageB);
            _stageB = stageloop1;
            isFar = true;

        }

        //지나간 배경 지우기
        if(_stageA != null && _stageA.transform.position.z < -50 && isFar == true)
        {
            GameObject stageloop2 = Instantiate(_stageA, new Vector3(0, 0, viewDist), transform.rotation);
            if(_stageA != null)
                DestroyImmediate(_stageA);
            _stageA = stageloop2;
            isFar = false;
        }
    }

    
}
