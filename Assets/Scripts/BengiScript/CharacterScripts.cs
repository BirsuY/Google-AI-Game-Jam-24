using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScripts : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;

    void Start()
    {
        // Rigidbody bile�enini bul ve ata, e�er inspector'dan atanmam��sa
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // Karakteri WASD ile d�nd�rmek i�in giri�leri al
        float moveHorizontal = Input.GetAxis("Horizontal"); // A ve D tu�lar� veya Sol ve Sa� ok tu�lar�
        float moveVertical = Input.GetAxis("Vertical"); // W ve S tu�lar� veya Yukar� ve A�a�� ok tu�lar�

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector3 direction)
    {
        // Kameran�n y�n�ne g�re hareketi d�n��t�r
        Vector3 move = direction * speed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
    }

}
