using UnityEngine;

public class AI : MonoBehaviour
{
    
    public bool canJump = false;

    public void CheckForObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        canJump = false;
        foreach (GameObject obstacle in obstacles)
        {

            float offset = obstacle.transform.rotation.z;
            Debug.Log(offset);
            if (Mathf.Abs(offset) < 100)
            {
                canJump = true;
                break;
            }
        }
    }

  
}