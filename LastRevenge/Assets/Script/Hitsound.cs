using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitsound : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DTime", 3f);
        
    }

    void DTime()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
