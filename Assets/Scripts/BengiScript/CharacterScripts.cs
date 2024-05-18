using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScripts : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;

    void Start()
    {
        // Rigidbody bileþenini bul ve ata, eðer inspector'dan atanmamýþsa
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // Karakteri WASD ile döndürmek için giriþleri al
        float moveHorizontal = Input.GetAxis("Horizontal"); // A ve D tuþlarý veya Sol ve Sað ok tuþlarý
        float moveVertical = Input.GetAxis("Vertical"); // W ve S tuþlarý veya Yukarý ve Aþaðý ok tuþlarý

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector3 direction)
    {
        // Kameranýn yönüne göre hareketi dönüþtür
        Vector3 move = direction * speed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
    }

}
