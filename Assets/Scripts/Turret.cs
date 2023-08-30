using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float fireDelay;
    [SerializeField]
    private bool isFiring;
    [SerializeField]
    private float turretPower;

    private float currentDelay;

    private void Update() {
        if(!isFiring) return;

        if(currentDelay + fireDelay < Time.time) return;

        currentDelay = Time.time;

        FireCannon();
    }

    public void FireCannon() {
        GameObject target = ObjectPool.Singleton.GetPooledObject();

        target.transform.position = firePoint.position;
        target.GetComponent<Rigidbody>().AddForce(firePoint.forward * turretPower, ForceMode.Impulse);
    }
}
