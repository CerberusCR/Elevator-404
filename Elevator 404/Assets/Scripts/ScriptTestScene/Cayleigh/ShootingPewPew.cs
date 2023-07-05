using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;


public class ShootingPewPew : MonoBehaviour
{
    public float damage = 69420f;
    public float range = 100f;

    public Camera fpsCam;
    public AudioSource gunShot;

    private bool isPaused = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }
    //Luuk may not be impressed but I got the drippy code sheeeeesh
    void Shoot()
    {
        if (isPaused == false)
        {

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.Damage(damage);
                }
            }
            gunShot.Play(); // Play the gunshot sound
        }
    }

    public void setPaused(bool paused)
    {
        isPaused = paused;
    }

}