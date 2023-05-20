using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ChangePlayerFocus : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera cinemachine;
    public void OnChangeFocus(Transform newFocus)
    {
        cinemachine.Follow = newFocus;
    }
}
