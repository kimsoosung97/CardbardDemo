﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMDEmulator : MonoBehaviour
{
    private Transform camTr;

    public float yawSpeed = 3.0f;   //Y축 회전 속도
    public float pitchSpeed = 3.0f; //X축 회전 속도

    // Start is called before the first frame update
    void Start()
    {
        camTr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() //60fps  1/60 sec 발생 빈도 불규칙
    {
        if (Input.GetKey(KeyCode.LeftAlt))  //GetKeyDown, GetKeyUp
        {
            //Debug.Log("LeftAlt pressed !!!");
            Vector3 mouseVec = new Vector3(-Input.GetAxis("Mouse Y") * pitchSpeed, Input.GetAxis("Mouse X") * yawSpeed, 0);

            Vector3 rot = camTr.localEulerAngles + mouseVec;

            //Quaternion.Euler(오일각도)  : 오일각(x,y,z) ==> 쿼터니언(x,y,z,w)
            //짐벌락(Gimbal Lock) 방지하기 위해서 쿼터니언을 사용
            camTr.localRotation = Quaternion.Euler(rot);
        }
    }

}
