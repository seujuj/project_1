using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEditor;
using System.Reflection;


public class AlignWithGround : MonoBehaviour {

	[MenuItem("Tools/Transform Tools/Align %t")]
	static void AlignToGround()
	{
		Transform[] transforms = Selection.transforms;
		foreach (Transform myTransform in transforms)
		{
			RaycastHit hit;
			if(Physics.Raycast(myTransform.position, -Vector3.up,out hit))
			{
				Vector3 targetPosition = hit.point;
				if(myTransform.GetComponent<MeshFilter>() != null)
				{
                    //Bounds bounds = myTransform.GetComponent<MeshFilter>().sharedMesh.bounds;
                    //targetPosition.y += bounds.extents.y;
                    myTransform.position = targetPosition;
                }
				myTransform.position = targetPosition;
				//Vector3 targetRotation = new Vector3(hit.normal.x, myTransform.eulerAngles.y, hit.normal.z);
				//myTransform.eulerAngles = targetRotation;
			}
		}
	}

    [MenuItem("Tools/Transform Tools/RoundOff %/")]
    static void RoundToNearestHalf()
    { 
        Transform[] curTransformArray = Selection.transforms;

        for(int i=0;i<curTransformArray.Length;++i)
        {
            Transform curTrans = curTransformArray[i];
            Vector3 localPos = curTrans.localPosition;

            localPos.x = Mathf.Round(localPos.x);
            localPos.y = Mathf.Round(localPos.y);
            localPos.z = Mathf.Round(localPos.z);

            curTrans.localPosition = localPos;
        }

    }


    [MenuItem("Tools/Transform Tools/위치 반올림 짝수 %#]")]
    static void SetPositionSnap1()
    {
        GameObject obj = Selection.activeGameObject;

        float xx = Mathf.Round(obj.transform.position.x);
        float yy = Mathf.Round(obj.transform.position.y);
        float zz = Mathf.Round(obj.transform.position.z);

        if (xx % 2 != 0)
            xx += 1;
        if (yy % 2 != 0)
            yy += 1;
        if (zz % 2 != 0)
            zz += 1;
        obj.transform.position = new Vector3(xx, yy, zz);
    }


    [MenuItem("Tools/Transform Tools/이동Y+1 %PGUP")]
    static void SetMoveCustomY1()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            Vector3 pos = curTrans.localPosition;
            pos.y += 1;
            curTrans.localPosition = pos;
        }
    }

    [MenuItem("Tools/Transform Tools/이동Y-1 %PGDN")]
    static void SetMoveCustomY2()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            Vector3 pos = curTrans.localPosition;
            pos.y -= 1;
            curTrans.localPosition = pos;
        }
    }
    [MenuItem("Tools/Transform Tools/이동x+1 %RIGHT")]
    static void SetMoveCustomX1()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            Vector3 pos = curTrans.localPosition;
            pos.x += 1;
            curTrans.localPosition = pos;
        }
    }
    [MenuItem("Tools/Transform Tools/이동x-1 %LEFT")]
    static void SetMoveCustomX2()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            Vector3 pos = curTrans.localPosition;
            pos.x -= 1;
            curTrans.localPosition = pos;
        }
    }
    [MenuItem("Tools/Transform Tools/이동z+1 %UP")]
    static void SetMoveCustomZ1()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            Vector3 pos = curTrans.localPosition;
            pos.z += 1;
            curTrans.localPosition = pos;
        }
    }
    [MenuItem("Tools/Transform Tools/이동z-1 %DOWN")]
    static void SetMoveCustomZ2()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            Vector3 pos = curTrans.localPosition;
            pos.z -= 1;
            curTrans.localPosition = pos;
        }
    }

    [MenuItem("TeenyWorld/단축메뉴/네비메쉬용으로 %#.")]
    static void SetForNavi()
    {
        //선택한 오브젝트를 네비메쉬용으로.
        //Transform[] curTransArray = Selection.transforms;

        //for (int i = 0; i < curTransArray.Length; ++i)
        //{
        //    GameObject obj = curTransArray[i].gameObject;
        //    Renderer rend = Selection.activeGameObject.GetComponent<Renderer>();
        //    Collider col = Selection.activeGameObject.GetComponent<Collider>();

        //    obj.transform.gameObject.tag = "NavMesh";
        //    obj.transform.gameObject.layer = 0;

        //    rend.enabled = true;

        //    if (col != null)
        //        col.enabled = false;
        //}

        //네비메쉬 오브젝트 하위 오브젝트를 네비메쉬용으로.
        GameObject nv = GameObject.Find("navigation_mesh");
        if (nv != null)
        {
            for (int i = 0; i < nv.transform.childCount; i++)
            {
                GameObject child = nv.transform.GetChild(i).gameObject;
                Renderer rend = nv.transform.GetChild(i).gameObject.GetComponent<Renderer>();

                child.transform.gameObject.tag = "NavMesh";
                child.transform.gameObject.layer = 0;

                rend.enabled = true;
            }
        }


    }


    [MenuItem("TeenyWorld/단축메뉴/일반용으로 %#,")]
    static void SetNormalObj()
    {
        //GameObject obj = Selection.activeGameObject;

        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            GameObject obj = curTransArray[i].gameObject;
            Renderer rend = Selection.activeGameObject.GetComponent<Renderer>();
            Collider col = Selection.activeGameObject.GetComponent<Collider>();

            obj.transform.gameObject.tag = "Untagged";
            obj.transform.gameObject.layer = 0;

            rend.enabled = true;

            if (col != null)
                col.enabled = false;
        }


    }

    [MenuItem("TeenyWorld/단축메뉴/걷기용레이어 %#/")]
    static void SetForWalkable()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {

            GameObject obj = curTransArray[i].gameObject;
            Renderer rend = Selection.activeGameObject.GetComponent<Renderer>();
            Collider col = Selection.activeGameObject.GetComponent<Collider>();

            obj.transform.gameObject.tag = "Untagged";
            obj.transform.gameObject.layer = 8;

            //rend.enabled = true;
            if (col != null)
            {
                col.enabled = true;
                //EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }

        }
    }


    [MenuItem("Tools/Transform Tools/회전스케일0 #0")]
    static void SetRotScale0()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            Quaternion rot = curTrans.localRotation;

            curTrans.localRotation = Quaternion.Euler(0, 0, 0);

        }
    }


    [MenuItem("Tools/Transform Tools/위치 0 ")]
    static void SetPos000()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];

            curTrans.localPosition = new Vector3(0, 0, 0);

            

        }
    }

    [MenuItem("Tools/Transform Tools/콤포넌트지우고0 ")]
    static void SetComponentRot0()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            Quaternion rot = curTrans.localRotation;

            curTrans.localRotation = Quaternion.Euler(0, 0, 0);

            MeshFilter mf = Selection.activeGameObject.GetComponent<MeshFilter>();
            DestroyImmediate(mf);
            MeshRenderer mr = Selection.activeGameObject.GetComponent<MeshRenderer>();
            DestroyImmediate(mr);
        }
    }


    [MenuItem("Tools/Toggle Inspector Lock %q")] // Ctrl + q
    static void ToggleInspectorLock()
    {
        ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
        ActiveEditorTracker.sharedTracker.ForceRebuild();
    }

    [MenuItem("Tools/Transform Tools/MeshCollider Add ")]
    static void SetMeshCollierAdd()
    {
        GameObject[] curOBJ = Selection.gameObjects;

        for (int i = 0; i < curOBJ.Length; ++i)
        {
            GameObject curCol = curOBJ[i];
            if(curCol.GetComponent<MeshCollider>() == null)
            {
                curCol.AddComponent<MeshCollider>();
            }
            
            //MeshCollider mc = Selection.activeGameObject.AddComponent<MeshCollider>();
            //mc.sharedMesh = 
        }
    }

    [MenuItem("Tools/Transform Tools/MeshCollider Del ")]
    static void SetMeshCollierDel()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];
            
                    
            DestroyImmediate(curTrans.GetComponent<MeshCollider>());
            

            //MeshCollider mf = Selection.activeGameObject.GetComponent<MeshCollider>();
            //DestroyImmediate(mf);

        }
    }



    [MenuItem("Tools/Transform Tools/가구 정리")]
    static void SetMeshRendererDel()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];

            if (curTrans.GetComponent<MeshRenderer>() != null)
            {
                Transform newOBJ = Instantiate(curTrans);
                
                newOBJ.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

                //Quaternion rot = curTrans.localRotation;
                Transform[] childList = newOBJ.GetComponentsInChildren<Transform>();
                if (childList != null)
                {
                    for (int j = 1; j < childList.Length; j++)
                    {
                        if (childList[j] != null)
                            DestroyImmediate(childList[j].gameObject);

                    }
                }
                newOBJ.SetParent(curTrans.transform);
                newOBJ.name = curTrans.name;

                DestroyImmediate(curTrans.GetComponent<MeshFilter>());
                DestroyImmediate(curTrans.GetComponent<MeshRenderer>());

                MeshRenderer[] childList2 = curTrans.GetComponentsInChildren<MeshRenderer>();

                
                if (childList2 != null && childList2.Length == 1)
                {
                    for (int k = 0; k < childList2.Length; k++)
                    {
                        if (childList2[k] != null && childList2[k].enabled == false)
                        {
                            //UnityEngine.Debug.LogWarningFormat(childList2[k].name);
                            DestroyImmediate(childList2[k]);
                        }
                        //else if(childList2[k] != null && childList2.Length > 0)
                        //{

                        //    Quaternion originRot = curTrans.GetChild(0).rotation;
                        //    Vector3 oriRotVec3 = originRot.eulerAngles;
                        //    childList2[k].transform.rotation = Quaternion.Euler(new Vector3(oriRotVec3.x, 180f, 0f));
                        //}
                    }

                    
                }

                //MeshRenderer[] childList3 = curTrans.GetComponentsInChildren<MeshRenderer>();
                //if (childList3 != null && childList2.Length > 1 )
                //{
                //    GameObject rmRoot = new GameObject("root");
                //    rmRoot.transform.SetParent(curTrans.transform);
                //    for (int k = 0; k < childList3.Length; k++)
                //    {
                //        if (childList3[k] != null && childList3.Length > 0)
                //        {
                //            childList3[k].transform.SetParent(rmRoot.transform);
                //        }
                //    }
                //    //Quaternion originRot = curTrans.GetChild(0).rotation;
                //    //Vector3 oriRotVec3 = originRot.eulerAngles;

                //    rmRoot.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                //}
            }
            //else if (curTrans.GetChild(0) != null)
            //{
            //    Quaternion originRot = curTrans.GetChild(0).rotation;
            //    Vector3 oriRotVec3 = originRot.eulerAngles;
                                
            //    curTrans.GetChild(0).rotation = Quaternion.Euler(new Vector3(oriRotVec3.x, 180f, 0f));
            //}
                

            //UnityEngine.Debug.LogWarningFormat(curTrans.name);


        }
    }

    [MenuItem("Tools/Transform Tools/사용하지 않는 렌더러 지우기")]
    static void SetUnusedMeshRendererDel()
    {
        Transform[] curTransArray = Selection.transforms;

        for (int i = 0; i < curTransArray.Length; ++i)
        {
            Transform curTrans = curTransArray[i];

            MeshRenderer[] childList2 = curTrans.GetComponentsInChildren<MeshRenderer>();
            if (childList2 != null)
            {
                for (int k = 0; k < childList2.Length; k++)
                {
                    if (childList2[k] != null && childList2[k].enabled == false)
                    {
                        //UnityEngine.Debug.LogWarningFormat(childList2[k].name);
                        DestroyImmediate(childList2[k]);
                    }
                    //else if(childList2[k] != null && childList2.Length > 0)
                    //{

                    //    Quaternion originRot = curTrans.GetChild(0).rotation;
                    //    Vector3 oriRotVec3 = originRot.eulerAngles;
                    //    childList2[k].transform.rotation = Quaternion.Euler(new Vector3(oriRotVec3.x, 180f, 0f));
                    //}
                }

            }

        }
    }



    [MenuItem("Tools/Transform Tools/LOD Group Add ")]
    static void SetLODGroupAdd()
    {
        GameObject[] curOBJ = Selection.gameObjects;

        for (int i = 0; i < curOBJ.Length; ++i)
        {
            GameObject curCol = curOBJ[i];
            curCol.AddComponent<LODGroup>();
            //var lods = new SortedList<int, GameObject>();
            //
            LODGroup group = curCol.GetComponent<LODGroup>();
            LOD[] lods = new LOD[1];
            lods[0] = new LOD(0.10f, null);
            //lodl.     //Se(LODFadeMode.CrossFade);
            group.fadeMode = LODFadeMode.CrossFade;
            group.animateCrossFading = true;


            group.SetLODs(lods);
            group.RecalculateBounds();






        }
    }

    [MenuItem("Tools/Transform Tools/애니메이터 항상 재생으로(컷씬용) ")]
    static void SetAlwaysAnimation()
    {
        GameObject[] curOBJ = Selection.gameObjects;

        for (int i = 0; i < curOBJ.Length; ++i)
        {
            GameObject curCol = curOBJ[i];


            Animator[] childList = curCol.GetComponentsInChildren<Animator>();
            if (childList != null)
            {
                //Debug.Log(childList[0].name);
                for (int j = 0; j < childList.Length; ++j)
                {
//                    Debug.Log("찾았다.1.5");
                    if (childList[j] != null && childList[j].cullingMode != AnimatorCullingMode.AlwaysAnimate)
                    {
                        childList[j].cullingMode = AnimatorCullingMode.AlwaysAnimate;
                        Debug.Log(childList[j].name);
                    }
                        
                }
            }

        }
    }

    [MenuItem("Tools/Transform Tools/Camera Create ")]
    static void Set3DPaintCamera()
    {
         
        GameObject MainCamera = new GameObject();
        MainCamera.name = "Camera3DPaint";
        MainCamera.AddComponent<Camera>();
        MainCamera.tag = "MainCamera";
        Selection.activeGameObject = MainCamera.gameObject;
        
        if (SceneView.lastActiveSceneView != null )
        {
            Vector3 pos = SceneView.lastActiveSceneView.camera.transform.localPosition;
            Quaternion rot = SceneView.lastActiveSceneView.camera.transform.localRotation;

            MainCamera.transform.position = pos;
            MainCamera.transform.rotation = rot;
        }
        

        // ▼ 이거는 씬뷰가 카메라 뷰로 바뀌는거.
        //SceneView.lastActiveSceneView.rotation = MainCamera.transform.rotation;
        //Vector3 position = MainCamera.transform.position + (MainCamera.transform.forward * 10);
        //SceneView.lastActiveSceneView.Repaint();



        //Vector3 position = SceneView.lastActiveSceneView.pivot;
        //SceneView.lastActiveSceneView.pivot = position;
        //SceneView.lastActiveSceneView.Repaint();
        //Camera:Camera = SceneView.lastActiveSceneView.camera;
    }


    [MenuItem("Tools/Transform Tools/카메라 선택")]
    static void SelectMaincamera()
    {
        GameObject gos = GameObject.Find("Main Camera");
        Selection.activeObject = gos;
    }

    [MenuItem("Tools/Transform Tools/메인라이트 선택")]
    static void SelectSun()
    {
        GameObject gos = GameObject.Find("MainLight");
        Selection.activeObject = gos;
    }

    [MenuItem("Tools/Transform Tools/캐릭터 선택")]
    static void SelectMe()
    {
        GameObject gos = GameObject.FindGameObjectWithTag("GameControlPlayer");
        Selection.activeObject = gos;
    }
    

    [MenuItem("Tools/Transform Tools/콘솔창 지우기")]
    static void SetClearConsoleLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    [MenuItem("Tools/Transform Tools/풀 그리기 (아직안됨ㅠ)")]
    static void SetGrassDraw()
    {


        //var ge = new TeenyInstancedGrassEditor()
        //var ge = TeenyInstancedGrassEditor.
            //if(ge != null)
            //{
            //    ge.GrassEditIndex = 1;
            //}




        
        //TeenyInstancedGrassEditor.SetGrass();

    }


        //[MenuItem("Tools/Transform Tools/선택한 매터리얼 텍스쳐 찾아주기")]
        //static void SetTextureMatchingMaterial()
        //{
        //    //GameObject obj = curTransArray[i].gameObject;
        //    //Renderer rend = Selection.activeGameObject.GetComponent<Renderer>();
        //    //Collider col = Selection.activeGameObject.GetComponent<Collider>();
        //    Object[] _objectsSelected = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        //    for (int i = 0; i < _objectsSelected.Length; ++i)
        //    {
        //        Material CurObj = _objectsSelected[i].GetType().


        //    }
        //    //Material curTrans = curTransArray[i];


        //    //Material obj = Selection.activeObject.get;
        //}





        //[MenuItem("Tools/Transform Tools/Open Doors(Temp)")]
        //static void SetOpenDoors()
        //{
        //    GameObject door = GameObject.FindGameObjectWithTag("Housing_Door");

        //    Animator anidoor = door.GetComponent<Animator>();
        //    if(door != null)
        //    {
        //        anidoor.Play("Base Layer.open", 0, 0);
        //    }


        //}

        //[MenuItem("Tools/Transform Tools/Close Doors(Temp)")]
        //static void SetCloseDoors()
        //{
        //    GameObject door = GameObject.FindGameObjectWithTag("Housing_Door");

        //    Animator anidoor = door.GetComponent<Animator>();
        //    if (door != null)
        //    {
        //        anidoor.Play("Base Layer.close", 0, 0);
        //    }


        //}



        //[MenuItem("Tools/Transform Tools/Creat House(Temp)")]
        //static void SetCreateHouse()
        //{
        //    GameObject.Find("CHHouse").transform.Find("Create_House00").gameObject.SetActive(true);

        //    GameObject crh = GameObject.Find ("Create_House00");

        //    if (crh != null)
        //    {
        //        crh.SetActive(true);

        //            //Animator anicreate = crh.GetComponent<Animator>();
        //            //anicreate.Play("Base Layer.Ani_Create_House00", 0, 0);


        //    }
        //}

        //[MenuItem("Tools/Transform Tools/Create Furniture(Temp)")]
        //static void SetCreateFurniture()
        //{
        //    GameObject.Find("h_00_we00_house00").transform.Find("Create_Furniture").gameObject.SetActive(true);

        //    GameObject crh = GameObject.Find("Create_Furniture");

        //    if (crh != null)
        //    {
        //        crh.SetActive(true);

        //        //Animator anicreate = crh.GetComponent<Animator>();
        //        //anicreate.Play("Base Layer.Ani_Create_House00", 0, 0);


        //    }
        //}


        //string st = "";
    //string stArea = "Empty List";
    Vector2 scrollPos;
    bool exact;



}

