using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canyon : MonoBehavior
{
     public float speed = 2.5f;

     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         float y = -1 * speed * Time.deltaTime;
         transform.position += new Vector3(0, y, 0);

         if (transform.position.y < -6) {
             Destroy(gameObject);
         }
     }
}
