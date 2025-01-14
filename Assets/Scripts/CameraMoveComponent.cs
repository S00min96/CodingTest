using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.AI;

public class CameraMoveComponent : MonoBehaviour
{
    public Canvas my_canva;
    public Camera[] SubCamera;
    public static int SceneNumber = 0;
    public GameObject WasherDoorArrow;
    public GameObject WasherDoor;
    public static Action<int> ChangeCamera;
    public static int CameraSceneChangeNumber = 0;
    private void Awake()
    {
        ChangeCamera = (int CameraSceneChangeNumber) => { MoveCameraSup(CameraSceneChangeNumber); };
        WasherDoorArrow.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SceneNumber == 0)
            {
                FirstScene();
                LocalizedComponent.MainTextNumber++;    // 2               
            }
            else if ((SceneNumber == 2 && WasherDoorClick.CheckNumber == 0) && VideoPlayManager.ReNum ==1)
            {
                FirstScene();
                WasherDoor.GetComponent<BoxCollider>().enabled = true;
                Debug.Log("퀴즈모드시작");
                LocalizedComponent.MainTextNumber++;    // 2
            }
            SceneNumber++;           
        }       
    }

    // 카메라를 목표 지점으로 이동
    public void MoveCamera(int index)
    {
        Vector3 new_position = SubCamera[index].transform.position;
        Vector3 new_rotation = SubCamera[index].transform.eulerAngles;

        iTween.MoveTo(this.gameObject, iTween.Hash("position", new_position, "easeType", iTween.EaseType.easeInSine, "time", 1.0f));
        iTween.RotateTo(this.gameObject, iTween.Hash("rotation", new_rotation, "easeType", iTween.EaseType.easeInSine, "time", 1.0f));
    }

    // 1번 카메라로 이동
    public void FirstScene()
    {
        MoveCamera(0);
        if (SceneNumber != 2)
            WasherDoorArrow.SetActive(true);
    }
    //  2번 카메라로 이동
    public void MoveCameraSup(int i)
    {
        if (i == 1)
            MoveCamera(i);
        else if (i == 2)
            MoveCamera(i);
        else if (i == 3)
            MoveCamera(i);
    }
    //  3번 카메라로 이동
   /* public void ThirdScene(int i)
    {
        MoveCamera(i);
    }*/
   
}
