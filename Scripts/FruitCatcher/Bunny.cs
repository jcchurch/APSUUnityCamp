using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{

    public float speed;
    public GameObject apple;
    public GameObject potato;

    private int direction;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, 4f, 0);
        direction = 1;
        Invoke("dropSomething", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x + (direction * speed * Time.deltaTime);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        if (transform.position.x >= 4f)
        {
            direction = -1;
        }

        if (transform.position.x <= -4f)
        {
            direction = 1;
        }
    }

    private void dropSomething()
    {
        GameObject toDrop = apple;
        if (UnityEngine.Random.Range(0, 1f) < 0.5)
        {
            toDrop = potato;
        }

        Instantiate(toDrop, transform.position, Quaternion.identity);
        Invoke("dropSomething", 3f);
    }
}
