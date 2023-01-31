using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRot : MonoBehaviour
{
    GameObject Player;
    PlayerController PC;

    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PC = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 vec = new Vector3(0.0f, 5.0f, 0f);
            target.transform.Rotate(vec);
        

    }
}
