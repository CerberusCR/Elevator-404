using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 69f;
    public GameObject confetti;


    public AudioSource audioSource;  // Reference to the audio source
    public AudioClip destroySound;  // Sound to play when the object is destroyed

    private void OnDestroy()
    {
        // Play the destroy sound when the object is destroyed
        audioSource.PlayOneShot(destroySound);
    }
    public void Damage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            GameObject deathConfetti = Instantiate(confetti,transform.position, Quaternion.identity);
            Destroy(deathConfetti, 1); //Destroys it after 1 seconds.
            Destroy(gameObject);
        }
    
    }
}
