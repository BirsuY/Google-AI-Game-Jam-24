using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScripts : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    bool oyunDurduMu;

    void Start()
    {
        oyunDurduMu = false;
        Time.timeScale = 1;
        
        if (rb == null) // Rigidbody bileþenini bul ve ata vee eðer inspector'dan atanmamýþsa
        {
            rb = GetComponent<Rigidbody>();
        }
        
    }

    void Update()
    {
        if (!oyunDurduMu)
        {          
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");  

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            MoveCharacter(movement);
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        if (!oyunDurduMu)
        {
            
            Vector3 move = direction * speed * Time.deltaTime; // Kameranýn yönüne göre hareketi dönüþtür
            rb.MovePosition(transform.position + move);
        }
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            oyunDurduMu = true;
            SceneManager.LoadScene("MainManu");
        }
    }

}
