using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    Image Image;
    // Start is called before the first frame update
    void Start()
    {

        Image = GetComponent<Image>();
        Image.DOFade(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
