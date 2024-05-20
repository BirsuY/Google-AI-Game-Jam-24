using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] GameObject obstacle1;
    [SerializeField] GameObject obstacle2;
    public bool canJump = false;

    public void CheckForObstacles()
    {
        canJump = false;

        if(Mathf.Abs(obstacle1.transform.rotation.z) < 160f || Mathf.Abs(obstacle2.transform.rotation.z) < 160f)
        { 
                canJump = true;
            
        }
    }

  
}