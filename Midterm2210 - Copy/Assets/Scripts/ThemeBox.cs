using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeBox: MonoBehaviour
{
    public float themeSpeed;
   // public float playerX;
    //public float playerY;

   
    //public Transform southPoint;
    
    //southPoint.position.y;
    // Update is called once per frame
    void Update()
    {
        MoveHazard();
    }

    void MoveHazard()
    {
        // Move the coin towards the south boundary
        transform.Translate(Vector3.down * themeSpeed * Time.deltaTime);


        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
       // if (((transform.position.y - playerY)< hitArea)&&((transform.position.x - playerX)< hitArea) )
       // {
           // Destroy(gameObject);
       // }
    }
}
