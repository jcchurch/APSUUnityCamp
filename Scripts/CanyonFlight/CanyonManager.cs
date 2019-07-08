using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonManager : MonoBehavior
{
     public GameObject canyon;
     public float gap = 14.0f;
     public float center = 0.0f;
     public int canyonEdgeCount = 0;

     // Start is called before the first frame update
     void Start()
     {
         for (float y = -4; y < 6; y++) {
             Instantiate(canyon, new Vector3(center - (gap / 2), y, 1), Quaternion.identity, transform);
             Instantiate(canyon, new Vector3(center + (gap / 2), y, 1), Quaternion.identity, transform);

             canyonEdgeCount += 2;
         }
     }

     // Update is called once per frame
     void Update()
     {
         if (canyonEdgeCount - transform.childCount >= 2) {
             gap = Mathf.Cos(Time.frameCount / 60.0f) + 16.0f;
             center = 5.0f * Mathf.Sin(Time.frameCount / 240.0f);
             Instantiate(canyon, new Vector3(center - (gap / 2), 4, 1), Quaternion.identity, transform);
             Instantiate(canyon, new Vector3(center + (gap / 2), 4, 1), Quaternion.identity, transform);
         }
     }
}
