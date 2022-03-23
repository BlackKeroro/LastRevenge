using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; //Playerble Direction

public class Title : MonoBehaviour
{
    public GameObject Stage; // StageUI�޾ƿ���
    public GameObject GM; //GameManager �޾ƿ���

    public GameObject[] Enemy; //

    public GameObject[] DTobj; //TimeLine�� ���� ���� ��ų ������Ʈ ����

    PlayableDirector PD;


    public void Awake()
    {
        Time.timeScale = 1;
        PD = GetComponent<PlayableDirector>();

        if (PlayerController.isLoad == true)
        {
            PD.time = 39.0f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnStart()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Invoke("StartTime", 5);
    }
    void StartTime()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponent<AttackGene>().enabled = true;
        Stage.SetActive(true);
        GM.SetActive(true);
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i].GetComponent<EnemyController>().enabled = true;
            
        }
        for (int i = 0; i < DTobj.Length; i++)
        {
            Destroy(DTobj[i]);
        }
    }


}
