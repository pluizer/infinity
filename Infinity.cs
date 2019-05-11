using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinity : MonoBehaviour
{
    public GameObject centerObject;
    public GameObject theObject;
    
    public Vector3 size = new Vector3(2, 0, 2);
    public float fieldOfView = 100;

    void Start()
    {
        float w = (int)Mathf.Floor(fieldOfView / size.x);
        float h = (int)Mathf.Floor(fieldOfView / size.z);
        Vector3 totalSize = new Vector3(w * size.x, 0, h * size.z);
        for (int i=0; i<w; i++) {
            for (int j=0; j<h; j++) {
                float x = (size.x * i) - (totalSize.x / 2);
                float y = (size.z * j) - (totalSize.z / 2);
                var obj = Object.Instantiate(theObject, new Vector3(x, 0, y), Quaternion.identity);
                obj.transform.parent = this.gameObject.transform;
            }
        }
        // disable the original
        theObject.SetActive(false);
        
    }

    void Update()
    {
        Vector3 position = centerObject.transform.position;
        float x = Mathf.Floor(position.x / size.x) * size.x;
        float z = Mathf.Floor(position.z / size.z) * size.z;
        this.gameObject.transform.position = new Vector3(x, 0, z);
    }
}
