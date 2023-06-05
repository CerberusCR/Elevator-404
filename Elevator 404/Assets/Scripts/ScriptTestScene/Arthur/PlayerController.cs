using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text display;


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
                if (lookingAtObject.GetComponent<ElectricObjects>().component == 2)
                {
                    display.text = "Press E to flip switch";
                }
                else if (lookingAtObject.GetComponent<ElectricObjects>().component == 5)
                {
                    display.text = "Press E to test circuit";
                }
                else
                {
                    display.text = "";
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    lookingAtObject.GetComponent<ElectricObjects>().Interact();
                    //print(lookingAtObject.GetComponent<MeshRenderer>().material);
                    //lookingAtObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
                }
            }
            else if (lookingAtObject.tag == "liftknop")
            {
                display.text = "Press E to go to the next level";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    lookingAtObject.GetComponent<Liftknop>().Interact();
                    //print(lookingAtObject.GetComponent<MeshRenderer>().material);
                    //lookingAtObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
                }
            }
            else
            {
                display.text = "";
            }
        }
        else
        {
            display.text = "";
        }

        //springen
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            onGround = false;
        }
    }
}
