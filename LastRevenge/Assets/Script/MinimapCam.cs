using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotS = target.transform.rotation.y;
        
        Vector3 vec = new Vector3(target.transform.position.x, target.transform.position.y + 200, target.transform.position.z);
        transform.position = vec;
        
        transform.rotation = Quaternion.Euler(0, target.transform.eulerAngles.y ,0);
        //Debug.Log(target.transform.eulerAngles.y);
     }
}
