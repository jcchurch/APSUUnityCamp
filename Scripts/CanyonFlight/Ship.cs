using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehavior
{
     public Text message;
     public float speed = 5.0f;

     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
         transform.position += new Vector3(x, 0, 0);

         message.text = "Score: " + Time.frameCount;
     }

     void OnTriggerEnter2D() {
         Destroy(gameObject);
     }
}
