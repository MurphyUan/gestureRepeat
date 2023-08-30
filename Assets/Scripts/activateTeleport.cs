using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleport : MonoBehaviour
{
    [SerializeField] private GameObject leftTeleport;
    [SerializeField] private GameObject rightTeleport;

    [SerializeField] private InputActionProperty leftActivate;
    [SerializeField] private InputActionProperty rightActivate;

    [SerializeField] private InputActionProperty leftCancel;
    [SerializeField] private InputActionProperty rightCancel;

    // Update is called once per frame
    void Update()
    {
        bool leftActive = leftCancel.action.ReadValue<float>() == 0.1f && leftActivate.action.ReadValue<float>() > 0.1f;
        bool rightActive = rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f; 

        leftTeleport.SetActive(leftActive);
        rightTeleport.SetActive(rightActive);
    }
}
