using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKScriptforSaatCubuklari : MonoBehaviour
{
    [SerializeField] float cubukDonmesi;
    [SerializeField] float tersCubukDonmesi;

    void Update()
    {
        transform.Rotate(Vector3.forward, -cubukDonmesi * Time.deltaTime * 3600);
        transform.Rotate(Vector3.forward, tersCubukDonmesi * Time.deltaTime * 3600);
    }


}


