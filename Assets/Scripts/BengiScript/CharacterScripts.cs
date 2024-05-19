using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScripts : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rb;
    bool oyunDurduMu;
    bool isGrounded;
    [SerializeField] Animator anim;
    


    void Start()
    {
        oyunDurduMu = false;
        Time.timeScale = 1;
        
        if (rb == null) // Rigidbody bile?enini bul ve ata vee e?er inspector'dan atanmam??sa
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

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                isGrounded = false;
            }

            // if (rb.velocity.y > 0)
            // {
            //     anim.SetBool("jump", true);
            // }
            // if (rb.velocity.y == 0)
            // {
            //     anim.SetBool("jump", false);
            // }

            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), .01f);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }


            
        }

      //  if (Input.GetKey(KeyCode.W))
      //  {
      //      print("gavurun tohumu goþuyoor");
      //      anim.SetBool("run", true);
      //  }
      //  else anim.SetBool("run", false);


    }

    void MoveCharacter(Vector3 direction)
    {
        if (!oyunDurduMu)
        {
            
            Vector3 move = direction * speed * Time.deltaTime; // Kameranin yonune gore hareketimiz dönüyo
            rb.MovePosition(transform.position + move);
         
        }
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        anim.SetTrigger("cump");
        
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            oyunDurduMu = true;
            SceneManager.LoadScene("MainManu");
        }

        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
          //  anim.SetBool("jump", false);
        }
       // else
       // {
       //    anim.SetBool("jump", true);
       // }
    }

}
