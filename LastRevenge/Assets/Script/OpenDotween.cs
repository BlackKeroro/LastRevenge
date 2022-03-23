using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OpenDotween : MonoBehaviour
{
    public GameObject MainText; // ����
    Text Main;
    public GameObject StartButton; // ���� ���� ��ư
    Image Start;
    public GameObject StartText;
    Text ST;
    public GameObject RuleButton; //���� �� ��ư
    Image Rule;
    public GameObject RuleText;
    Text RT;
    bool isStart = false;

    public GameObject GM;
    public GameObject StageUi;


    public GameObject CineCam;
    public GameObject MainCam;
    public Transform CamPos;

    public void Awake()
    {
        Main = MainText.GetComponent<Text>();
        Start = StartButton.GetComponent<Image>();
        ST = StartText.GetComponent<Text>();
        Rule = RuleButton.GetComponent<Image>();
        RT = RuleText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true && isStart == false)
        {
            
            Main.DOFade(1, 2); // ������ 1(�ִ�ġ)��ŭ 2�ʿ� ���� �����
            Start.DOFade(1, 2);
            Rule.DOFade(1, 2);
            ST.DOFade(1, 3);
            RT.DOFade(1, 4);
        }
    }

    public void OnStart()
    {
        Destroy(CineCam);
        MainCam.SetActive(true);
        isStart = true;
        Main.DOFade(0, 2); // ������ 1(�ִ�ġ)��ŭ 2�ʿ� ���� �����
        ST.DOFade(0, 2);
        RT.DOFade(0, 2);
        Start.DOFade(0, 2);
        Rule.DOFade(0, 2);
        
        StartCoroutine("CamMove");
    }

    public IEnumerator CamMove()
    {
        yield return new WaitForSeconds(1.8f);
        StartText.SetActive(false);
        RuleText.SetActive(false);
        gameObject.SetActive(false);
        MainCam.transform.DOMove(new Vector3(CamPos.transform.position.x, CamPos.transform.position.y, CamPos.transform.position.z), 3).SetEase(Ease.InCubic);
        MainCam.transform.DORotate(new Vector3(14.0f, 0,0), 3).SetEase(Ease.InCubic);
    }
}
