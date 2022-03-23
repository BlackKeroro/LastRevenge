using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeepSilder : MonoBehaviour
{
    public GameObject player;


    public Slider Slider;

    private float Back = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Back = PlayerPrefs.GetFloat("Back", 0f);
        Slider.value = Back;
    }

    // Update is called once per frame
    void Update()
    {
        Back = - player.transform.position.y;
        Slider.value = Back / 300.0f;
        
    }
}
