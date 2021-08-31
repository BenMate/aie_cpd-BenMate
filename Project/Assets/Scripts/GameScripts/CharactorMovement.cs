using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//#if UNITY_ANDROID || UNITY_EDITOR
// Debug.log("ANDROID INIT");
//#endif

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Animator))]
public class CharactorMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;

    Animator animator;
    Rigidbody rb;

    public Camera cam;
    Vector3 worldMousePos = Vector3.zero;

    public GameObject head;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        WalkControls();

        LookControls();
    }

    void WalkControls()
    {
        Vector3 localVel = rb.velocity;

        localVel.z = -Input.GetAxis("Vertical") * movementSpeed;
        localVel.x = -Input.GetAxis("Horizontal") * movementSpeed;

        rb.velocity = localVel;

        animator.SetBool("isWalking", rb.velocity.magnitude > 0.1f);
    }

    void LookControls()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, int.MaxValue))
        {
            worldMousePos = hit.point;
        }

        if (Time.timeScale > 0)
        {
            transform.LookAt(new Vector3(worldMousePos.x, transform.position.y, worldMousePos.z));
            head.transform.LookAt(worldMousePos);
        }
        
    }

}
