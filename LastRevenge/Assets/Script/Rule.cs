using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rule : MonoBehaviour
{

    public GameObject RuleOn;
    public GameObject OnePage;
    public GameObject TwoPage;

    public GameObject StartButton;
    public GameObject RuleButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnRule()
    {
        RuleOn.SetActive(true);
        OnePage.SetActive(true);
        TwoPage.SetActive(false);
        StartButton.SetActive(false);
        RuleButton.SetActive(false);
    }

    public void ExitRule()
    {
        RuleOn.SetActive(false);
        StartButton.SetActive(true);
        RuleButton.SetActive(true);
    }
    public void OnOnePage()
    {
        TwoPage.SetActive(false);
        OnePage.SetActive(true);
    }
    public void OnTwoPage()
    {
        OnePage.SetActive(false);
        TwoPage.SetActive(true);
    }

}
