using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(target.transform.position.x, 0.0f, target.transform.position.z);
        transform.Translate(vec);
    }
}
