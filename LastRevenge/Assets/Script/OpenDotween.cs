using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OpenDotween : MonoBehaviour
{
    public GameObject MainText; // 제목
    Text Main;
    public GameObject StartButton; // 게임 시작 버튼
    Image Start;
    public GameObject StartText;
    Text ST;
    public GameObject RuleButton; //게임 룰 버튼
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
            
            Main.DOFade(1, 2); // 투명도를 1(최대치)만큼 2초에 걸쳐 만들기
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
        Main.DOFade(0, 2); // 투명도를 1(최대치)만큼 2초에 걸쳐 만들기
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
