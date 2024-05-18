using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKScriptforSaatCubuklari : MonoBehaviour
{
    [SerializeField] float cubukDonmesi = 0.1f;

    void Update()
    {
        transform.Rotate(Vector3.forward, -cubukDonmesi * Time.deltaTime * 3600);
    }


}


