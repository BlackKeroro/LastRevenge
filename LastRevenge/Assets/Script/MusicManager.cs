using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [Header("Water Source")]
    public AudioSource Water;
    public AudioSource UnderWater;
    bool IsUnderWater = false;

    GameObject player;

    [Header("Music Source")]
    public AudioSource Opning;
    public

    void Awake()
    {
        if(PlayerController.isLoad == true)
        {
            Opning.time = 39.0f;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > -1.5f && IsUnderWater == true)
        {
            Water.Play();
            UnderWater.Pause();
            IsUnderWater = false;
        }
        else if(player.transform.position.y <= -1.5f && IsUnderWater == false)
        {
            Water.Pause();
            UnderWater.Play();
            IsUnderWater = true;
        }

    }
}
