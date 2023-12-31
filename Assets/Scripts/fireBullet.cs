using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    [SerializeField] 
    private LineRenderer lineRenderer;
    [SerializeField] 
    private Transform firePoint;
    [SerializeField] 
    private float range = 100f;

    private XRGrabInteractable grabbable;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Shoot);
    }

    private void Shoot(ActivateEventArgs args)
    {
        bool hasHit = Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hitInfo, range);

        LineRenderer line = Instantiate(lineRenderer);
        line.SetPositions(new Vector3[] { firePoint.position, hasHit ? hitInfo.point :
            firePoint.position + firePoint.forward * range});

        Destroy(line.gameObject, 0.1f);

        if(!hasHit) return;

        Rigidbody rb = hitInfo.transform.GetComponent<Rigidbody>();
        if(rb != null) {
            rb.AddForce(firePoint.forward * 10, ForceMode.Impulse);
        }
            
        Target _target = hitInfo.transform.GetComponent<Target>();
        if (_target != null) {
            int score = _target.returnScore();
        };

        Player _player = hitInfo.transform.GetComponent<Player>();
        if (_player != null) {
            Application.Quit();
        }
    }
}
