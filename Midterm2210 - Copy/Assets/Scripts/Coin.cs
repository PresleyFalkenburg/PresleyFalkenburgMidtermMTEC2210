using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float coinSpeed;
    //public Transform southPoint;
    float bottomBoundary =  (-5);
    public int value = 1;
    void Update()
    {
        MoveCoin();
    }

    void MoveCoin()
    {
        // Move the coin towards the south boundary
        transform.Translate(Vector3.down * coinSpeed * Time.deltaTime);


        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
        //if (transform.position.y - playerY < hitArea)
        //{
        //    Destroy(gameObject);
        //}
    }
}
