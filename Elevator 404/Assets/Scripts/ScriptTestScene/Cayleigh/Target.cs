using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 69f;

    public void Damage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
