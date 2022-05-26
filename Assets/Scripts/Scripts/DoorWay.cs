using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DoorWay : MonoBehaviour
{
    public CinemachineVirtualCamera camActivate; 
    public Vector3 destination;

    private void OnTriggerEnter(Collider other)
    {
        CamManager.INSTANCE.ChangeCam();
    }
}
