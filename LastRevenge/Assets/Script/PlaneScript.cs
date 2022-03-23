using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    Material mr;
    public Shader SD;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<Renderer>().sharedMaterial;
        SD = GetComponent<Shader>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
