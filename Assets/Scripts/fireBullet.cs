using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class fireBullet : MonoBehaviour
{
    [SerializeField] private GameObject line;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float range = 100f;

    private XRGrabInteractable grabbable;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireBullet(ActivateEventArgs args)
    {
        RaycastHit hitInfo;
        bool hasHit = Physics.Raycast(firePoint.position, firePoint.forward, out hitInfo, range);

        GameObject liner = Instantiate(line);
        liner.GetComponent<LineRenderer>().SetPositions(new Vector3[] { firePoint.position, hasHit ? hitInfo.point :
            firePoint.position + firePoint.forward * range});

        Destroy(liner, 0.5f);

        if(!hasHit) return;
            
        target _target = hitInfo.transform.GetComponent<target>();
        if (_target != null) {
            int score = _target.returnScore();
        };

        player _player = hitInfo.transform.GetComponent<player>();
        if (_player != null) {
            Application.Quit();
        }
    }
}
