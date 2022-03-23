using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score;
    public GameObject Scoreobj;
    Text ScoreText;

    public int hp;
    public GameObject Hpbar;
    Image HpImg;
    public GameObject Fade;

    AttackGene AG;
    public GameObject RAttackUI;
    Image RAttack;
    public float RTime;
    public GameObject LAttackUI;
    Image LAttack;
    public float LTime;
    public GameObject RepairUI;
    Image Repair;
    public float ReTime;

    public GameObject GO;
    void Awake()
    {
        Score = 0;
        hp = 10;

    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = Scoreobj.GetComponent<Text>();
        HpImg = Hpbar.GetComponent<Image>();
        AG = GameObject.Find("Player").GetComponent<AttackGene>();
        RAttack = RAttackUI.GetComponent<Image>();
        LAttack = LAttackUI.GetComponent<Image>();
        Repair = RepairUI.GetComponent<Image>();

        RAttack.fillAmount = 0;
        LAttack.fillAmount = 0;
        Repair.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + Score.ToString();
        HpImg.fillAmount = (float)hp / 10;
        if(AG.isRAttack == false)
        {
            RTime -= Time.deltaTime;
            RAttack.fillAmount = RTime / 10.0f;
            if(RTime <= 0.0f)
            {
                RTime = 0.0f;
            }
        }
        else if(AG.isRAttack == true)
        {
            RAttack.fillAmount = 0;
        }
        if (AG.isLAttack == false)
        {
            LTime -= Time.deltaTime;
            LAttack.fillAmount = LTime / 10.0f;
            if (LTime <= 0.0f)
            {
                LTime = 0.0f;
            }
        }
        else if (AG.isLAttack == true)
        {
            LAttack.fillAmount = 0;
        }

        if(AG.isRepair == false)
        {
            ReTime -= Time.deltaTime;
            Repair.fillAmount = ReTime / 15.0f;
        }
        else if (AG.isRepair == true)
        {
            Repair.fillAmount = 0;
        }
        
        if(hp <= 0)
        {
            Fade.SetActive(true);
            Invoke("GameOver", 4);
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        GO.SetActive(true);
    }
}
