using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour 
{
    [SerializeField] 
    private LineRenderer lineRenderer;
    [SerializeField] 
    private Transform firePoint;
    [SerializeField] 
    private float range = 100f;
    [SerializeField]
    private int maxAmmo = 10;
    [SerializeField]
    private float power = 10f;

    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip fire;
    [SerializeField]
    private AudioClip reload;
    [SerializeField]
    private AudioClip noammo;

    private int currentAmmo;
    private XRGrabInteractable grabbable;

    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Shoot);
    }

    private void Update() {
        if (Vector3.Angle(transform.up, Vector3.up) > 80 && currentAmmo < maxAmmo)
            Reload();

        //text.text = currentAmmo.ToString();
    }

    private void Reload()
    {
        currentAmmo = maxAmmo;
        //source.PlayOneShot(reload);
    }

    private void Shoot(ActivateEventArgs args)
    {
        if(currentAmmo < 0) {
            //source.PlayOneShot(empty);
            return;
        }

        //source.PlayOneShot(fire);
        currentAmmo--;

        bool hasHit = Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hitInfo, range);

        LineRenderer line = Instantiate(lineRenderer);
        line.SetPositions(new Vector3[] { firePoint.position, hasHit ? hitInfo.point :
            firePoint.position + firePoint.forward * range});

        Destroy(line.gameObject, 0.1f);

        if(!hasHit) return;

        Rigidbody rb = hitInfo.transform.GetComponent<Rigidbody>();
        if(rb != null) {
            rb.AddForce(firePoint.forward * power, ForceMode.Impulse);
        }
            
        Target _target = hitInfo.transform.GetComponent<Target>();
        if (_target != null) {
            int score = _target.returnScore();
            return;
        };

        Player _player = hitInfo.transform.GetComponent<Player>();
        if (_player != null) {
            Application.Quit();
        }
    }
}