using UnityEngine;

public class AI : MonoBehaviour
{
    public float jumpForce = 5f;  
    public Vector3 jumpDistance = new Vector3(2f, 0f, 0f);  
    public Rigidbody rb;
    public bool canJump = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    public void Update()
    {
        CheckForObstacles();

        if (canJump)
        {
            Jump_AI();
        }
    }

    public void CheckForObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        canJump = false;

        foreach (GameObject obstacle in obstacles)
        {
            Vector3 offset = transform.position - obstacle.transform.position;
            if (Mathf.Abs(offset.x) <= jumpDistance.x && Mathf.Abs(offset.y) <= jumpDistance.y && Mathf.Abs(offset.z) <= jumpDistance.z)
            {
                canJump = true;
                break;
            }
        }
    }

    public void Jump_AI()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false;  
    }
}