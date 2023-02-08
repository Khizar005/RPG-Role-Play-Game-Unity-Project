using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Camers : MonoBehaviour
{
    private CinemachineVirtualCamera VC;

    void Start()
    {
        VC = GetComponent<CinemachineVirtualCamera>();
        VC.Follow = Player.instance.transform;
    }
}
