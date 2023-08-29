using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Vector3 rotationDirection = new Vector3();

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);
    }
}
