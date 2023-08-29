using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class activateTeleport : MonoBehaviour
{
    [SerializeField] private GameObject leftTeleport;
    [SerializeField] private GameObject rightTeleport;

    [SerializeField] private InputActionProperty leftActivate;
    [SerializeField] private InputActionProperty rightActivate;

    // Update is called once per frame
    void Update()
    {
        leftTeleport.SetActive(leftActivate.action.ReadValue<float>() > 0.1f);
        rightTeleport.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
