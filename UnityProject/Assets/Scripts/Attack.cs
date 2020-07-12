using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Attack : MonoBehaviour
{
    public Transform aimPosition;
    public Transform FirePoint;
    public GameObject bullet;
    // Start is called before the first frame update
    void Awake()
    {
        //aimPosition = transform.Find("AimPosition");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = GetMousePosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimPosition.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public static Vector3 GetMousePosition()
    {
        Camera worldCamera = Camera.main;
        Vector3 vec = worldCamera.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }

    void Fire()
    {
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
    }
}
