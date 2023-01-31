using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    float End;
    Text txt;

    GameManager GM;
    public GameObject GameM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameM.GetComponent<GameManager>();
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        End = GM.Score;
        txt.text = End.ToString();
    }
}
