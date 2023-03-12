using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject _stageA;
    public GameObject _stageB;
    public GameObject _player;
    public GameObject _deadUI;
    //public GUIContent _deadui;
    //public GameObject _stageC;
    public float speed;
    //public int startIndex;
    //public int endIndex;
    //public Transform[] _stage1;

    public float viewDist = 10;
    //public float offDist = 10;
    private bool isFar = false;

    void Start()
    {
        _deadUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //  -------------- 배경이 모듈일 경우 다가오는 코드 
        //Vector3 curPos = _stageA.transform.position;
        //Vector3 nextPos = Vector3.back * speed * Time.deltaTime;
        //if (_stageA != null || _stageB != null)//&& _stageC != null)
        //{
        //_stageA.transform.position += nextPos;
        //_stageB.transform.position += nextPos;
        //_stageC.transform.position += nextPos;
        //}


        
        //if (_stageA != null && _stageA.transform.position.z < 0 && isFar == false)
        //{

        //    GameObject stageloop1 = Instantiate(_stageB, new Vector3(0, 0, viewDist), transform.rotation);


        //    if (_stageB != null && _stageB.transform.position.z < -viewDist + 10)
        //        DestroyImmediate(_stageB);
        //    //OnTriggerEnter ;
        //    _stageB = stageloop1;
        //    isFar = true;
        //}

        //if (_stageA != null && _stageA.transform.position.z < -viewDist && isFar == true)
        //{
        //    GameObject stageloop2 = Instantiate(_stageA, new Vector3(0, 0, viewDist), transform.rotation);
        //    if (_stageA != null)
        //        DestroyImmediate(_stageA);
        //    _stageA = stageloop2;
        //    isFar = false;
        //}

        

        

    }


    void GameOver()
    {
        Player player = GameObject.Find("PC").GetComponent<Player>();
        
        if(player.isDead == true)
        {
            Debug.Log("dead!");
            //speed = 0;
            //_deadUI.active = true;  //아직 유아이까지는.
        }
        
    }    


    public void DoRevive()
    {
        _deadUI.SetActive(false);
        Player player = GameObject.Find("PC").GetComponent<Player>();
        player.isDead = false;
        //speed = 10;

    }

    //GameObject _enemy = GameObject.FindGameObjectWithTag("deadZone");
    
    //void OnTriggerEnter(Collider collider, GameObject _player)
    //{
    //    if (collider.gameObject.tag == "deadZone")
    //    {
    //        Destroy(_player);
    //        speed = 0;
    //        //_deadui.
    //    }
    //}


}
