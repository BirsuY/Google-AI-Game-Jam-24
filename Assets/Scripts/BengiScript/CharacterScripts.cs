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
    private AudioSource audioSource;
    // public GameObject doguncakiVFX;
    //public float vfxYokEtmeSuresi = 30f;
    float Starttime;
    public bool canJump;
    AI ai;


    void Start()
    {
        oyunDurduMu = false;
        Time.timeScale = 1;
        ai.canJump = false;
        audioSource = GetComponent<AudioSource>();

        if (rb == null) // Rigidbody bile?enini bul ve ata vee e?er inspector'dan atanmam??sa
        {
            rb = GetComponent<Rigidbody>();
        }

        Invoke("PlaySoundAfterDelay", 15f);

      //  DontDestroyOnLoad(gameObject);
      //  ActivateVFX();

    }

  // void ActivateVFX()
  // {
  //     // VFX prefab'?ndan bir klon olu?tur ve karakterin pozisyonuna yerle?tir
  //     GameObject vfxInstance = Instantiate(doguncakiVFX, transform.position, Quaternion.identity);
  //     // VFX'in ebeveynini bu GameObject'e ayarla
  //     vfxInstance.transform.parent = transform;
  // } 

        void PlaySoundAfterDelay()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
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
            if (isGrounded && ai.canJump)
            {
                Jump();
                ai.canJump = false;
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
      //      print("gavurun tohumu go?uyoor");
      //      anim.SetBool("run", true);
      //  }
      //  else anim.SetBool("run", false);


    }

    void MoveCharacter(Vector3 direction)
    {
        if (!oyunDurduMu)
        {
            
            Vector3 move = direction * speed * Time.deltaTime; // Kameranin yonune gore hareketimiz d?n?yo
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
            MusicManager.instance.StopMusic();
            SceneManager.LoadScene("MainManu");
        }

        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;

          //  GameObject vfx = Instantiate(doguncakiVFX, transform.position, transform.rotation);
          //  Destroy(vfx, 30f);

            //  anim.SetBool("jump", false);
        }

        if(other.gameObject.tag == "Activator")
        {
            Destroy(other.gameObject);
            Starttime = Time.time; 
            float t = 0;
            ai.CheckForObstacles();
            while ( t < 10)
            {
                t = Mathf.FloorToInt((Time.time - Starttime) % 60);
                ai.CheckForObstacles();
            }
            
        }
        // else
        // {
        //    anim.SetBool("jump", true);
        // }
    }



}
