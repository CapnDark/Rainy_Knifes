using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
