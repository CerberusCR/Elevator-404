using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 69f;
    public GameObject confetti;

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
