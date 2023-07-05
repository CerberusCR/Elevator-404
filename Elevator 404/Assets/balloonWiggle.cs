using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class balloonWiggle : MonoBehaviour
{
    private float range;
    private float speed;         

    private Vector3 start;
    private float time = 0f;

    private void Start()
    {
        start = transform.position;

        range = Random.Range(0.05f, 0.2f);
        speed = Random.Range(0.1f, 1.0f);

    }

    private void Update()
    {
        Vector3 newPosition = start + Vector3.up * Mathf.Sin(time * speed) * range;

        transform.position = newPosition;

        time += Time.deltaTime;
    }
}
