using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRot : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(-target.transform.rotation.x, -target.transform.rotation.y, -target.transform.rotation.z);
        transform.localRotation = Quaternion.Euler(vec);
    }
}
