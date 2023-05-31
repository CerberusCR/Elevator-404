using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 move;
    public Vector3 cameraDraaien1;
    public Vector3 cameraDraaien2;
    public float h;
    public float v;
    public float speed;
    public float x;
    public float y;
    public float sensitivity;
    public bool onGround;
    public GameObject cam;
    public RaycastHit hit;
    public GameObject lookingAtObject;
    public Rigidbody rb;
    public float jumpHeight;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //input
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        x = Input.GetAxis("Mouse X");

        y -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        move.x = h;
        move.z = v;
        move.Normalize();


        cameraDraaien1.y = x;
        y = Mathf.Clamp(y, -90, 90);

        //movement
        transform.Translate(move * Time.deltaTime * speed);
        transform.Rotate(cameraDraaien1 * Time.deltaTime * sensitivity);
        cam.transform.localRotation = Quaternion.Euler(y, 0, 0);

        //raycast voor interactie
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 5))
        {
            lookingAtObject = hit.collider.gameObject;
            
            if (lookingAtObject.tag == "component")
            {
                //display text
                if (Input.GetKeyDown(KeyCode.E))
                {
                    lookingAtObject.GetComponent<ElectricObjects>().Interact();
                    //print(lookingAtObject.GetComponent<MeshRenderer>().material);
                    //lookingAtObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
                }
            }
        }

        //springen
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            onGround = false;
        }
    }
}
