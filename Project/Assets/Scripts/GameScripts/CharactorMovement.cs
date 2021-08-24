using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;

    public Transform target;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //if its on android
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    OnAndroid = true;
        //}

        

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 localVel = transform.InverseTransformDirection(rb.velocity);

        localVel.z = Input.GetAxis("Vertical") * movementSpeed;
        localVel.x = Input.GetAxis("Horizontal") * movementSpeed;

        rb.velocity = transform.TransformDirection(localVel);
    }
}
