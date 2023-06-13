using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public Vector3 move;
    public Vector3 cameraDraaien1;
    
    public float h;
    public float v;
    public float movementSpeed;
    public float x;
    public float y;
    public float mouseSensitivity;
    public bool onGround;
    public GameObject cam;
    public RaycastHit hit;
    public GameObject lookingAtObject;
    public Rigidbody rb;
    public float jumpHeight;
    public TMP_Text display;
    public bool inHand;
    public GameObject objectInHand;
    public GameObject handPosition;
    


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

        y -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        move.x = h;
        move.z = v;
        move.Normalize();


        cameraDraaien1.y = x;
        y = Mathf.Clamp(y, -90, 90);

        //movement
        transform.Translate(move * Time.deltaTime * movementSpeed);
        transform.Rotate(cameraDraaien1 * Time.deltaTime * mouseSensitivity);
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
                }
            }
            else if (lookingAtObject.tag == "liftknop")
            {
                display.text = "Press E to go to the next level";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    lookingAtObject.GetComponent<Liftknop>().Interact();
                }
            }
            else if (lookingAtObject.tag == "PickUpable")
            {
                display.text = "Press E to pick this up";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (inHand)
                    {
                        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
                        objectInHand.transform.position = (cam.transform.position + (hit.point - cam.transform.position) * 0.9f);
                        objectInHand = lookingAtObject;
                        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
                    }
                    else
                    {

                        objectInHand = lookingAtObject;
                        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
                        inHand = true;
                    }

                }
                
            }
            else
            {
                display.text = "";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (inHand)
                    {
                        inHand = false;
                        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
                        objectInHand.transform.position = (cam.transform.position + (hit.point - cam.transform.position) * 0.9f);
                        objectInHand = null;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (inHand == true)
                    {
                        if (objectInHand.name == "zaklamp")
                        {
                            objectInHand.GetComponent<Light>().enabled = !objectInHand.GetComponent<Light>().enabled;
                        }
                    }
                }
            }
        }
        else
        {
            display.text = "";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inHand)
                {
                    inHand = false;
                    objectInHand.GetComponent<Rigidbody>().isKinematic = false;
                    objectInHand.transform.position = cam.transform.position + cam.transform.forward * 4.5f;
                    objectInHand = null;
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (inHand == true)
                {
                    if (objectInHand.name == "zaklamp")
                    {
                        objectInHand.GetComponent<Light>().enabled = !objectInHand.GetComponent<Light>().enabled;
                    }
                }
            }
        }

        //springen
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            onGround = false;
        }

        //pickup
        if (inHand == true)
        {
            objectInHand.transform.position = handPosition.transform.position;
            objectInHand.transform.rotation = handPosition.transform.rotation;
        }



    }
}