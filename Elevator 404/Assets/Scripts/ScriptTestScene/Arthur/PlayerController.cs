
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public Vector3 move;
    public Vector3 cameraDraaien1;
    public bool controllDisplay;
    
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
    public bool hasBeenInteractedWith;
    


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
            else if (lookingAtObject.tag == "keycode")
            {
                display.text = "Press E to enter the code";
            }
            else if (lookingAtObject.tag == "praathond")
            {
                display.text = "Press E to talk with this dog";
            }
            else if (lookingAtObject.tag == "SnapToKeyPad")
            {
                if (hasBeenInteractedWith == false)
                {
                    display.text = "Find a Button to continue";
                }
                if (inHand)
                {
                    if (objectInHand.name == "Lift_knop")
                    {
                        display.text = "Press E to place the Button";
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hasBeenInteractedWith = true;
                            display.text = "";
                            inHand = false;
                            objectInHand.transform.position = lookingAtObject.transform.GetChild(0).gameObject.transform.position;
                            objectInHand.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                            objectInHand.transform.Rotate(new Vector3(90, 0, 0));
                            objectInHand.transform.localScale = new Vector3(1f, 1f, 1f);
                            objectInHand.tag = "liftknop";
                            objectInHand.GetComponent<Collider>().enabled = true;
                            objectInHand = null;
                        }
                    }
                }
            }
            else if (lookingAtObject.tag == "PickUpable")
            {
                display.text = "Press E to pick this up";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (inHand)
                    {
                        if (objectInHand.name == "Kermis rifle")
                        {
                            this.GetComponent<ShootingPewPew>().enabled = false;
                        }
                        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
                        objectInHand.GetComponent<Collider>().enabled = true;
                        objectInHand.transform.position = (cam.transform.position + (hit.point - cam.transform.position) * 0.9f);
                        objectInHand = lookingAtObject;
                        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
                        objectInHand.GetComponent<Collider>().enabled = false;

                    }
                    else
                    {

                        objectInHand = lookingAtObject;
                        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
                        objectInHand.GetComponent<Collider>().enabled = false;
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
                        if (objectInHand.name == "Kermis rifle")
                        {
                            this.GetComponent<ShootingPewPew>().enabled = false;
                        }
                        inHand = false;
                        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
                        objectInHand.GetComponent<Collider>().enabled = true;
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
                            objectInHand.transform.GetChild(0).GetComponent<Light>().enabled = !(objectInHand.transform.GetChild(0).GetComponent<Light>().enabled);
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
                    objectInHand.GetComponent<Collider>().enabled = true;
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
                        objectInHand.transform.GetChild(0).GetComponent<Light>().enabled = !(objectInHand.transform.GetChild(0).GetComponent<Light>().enabled);
                    }
                }
            }
        }

        //springen
        //if (Input.GetKeyDown(KeyCode.Space) && onGround)
        //{
            //rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            //onGround = false;
       // }

        //pickup
        if (inHand == true)
        {
            objectInHand.transform.position = handPosition.transform.position;
            objectInHand.transform.rotation = handPosition.transform.rotation;
            if (objectInHand.name == "Kermis rifle")
            {
                objectInHand.transform.Rotate(new Vector3(0, 180, -90));
                this.GetComponent<ShootingPewPew>().enabled = true;
            }
        }

    }
}
