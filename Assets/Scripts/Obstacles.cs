using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float x = 0.0f;
    private Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.transform;
        Debug.Log("This is the:" + gameObject.name + "Position Y:" + t.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        x -= Time.deltaTime;
        Debug.Log("updated X value:" + x);
        t.position = new Vector3(0, x, 0);
    }
}
