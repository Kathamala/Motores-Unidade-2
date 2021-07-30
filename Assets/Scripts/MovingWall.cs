using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{

    public float speed = 6f;
    public float maxX = 30f;
    public float minX = 14f;
    // Start is called before the first frame update
    Rigidbody rb;
 
    Vector3 direction;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        direction = Vector3.right;
    }

    void Update ()
    {
        rb.velocity = direction * speed;

        if(transform.position.x < maxX){
            direction = Vector3.right;
        }

        if(transform.position.x >= minX){
            direction = Vector3.left;
        }
    }

}
