using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGene : MonoBehaviour
{
    //발사 제한 true = 발사 가능, false = 불가능
    public bool isRAttack = true;
    public bool isLAttack = true;
    public bool isRepair = true;
    float RepairTime = 0.0f;
    public float MaxRepairtime = 15.0f;
    public AudioSource Repair;

    //오브젝트 발사 위치 값, 발사할 오브젝트
    public Transform RPos;
    public Transform LPos;
    public GameObject RBullet;
    public GameObject LBullet;

    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 클릭 시 발사
        if(Input.GetButtonDown("Fire1"))
        {
            //우측 공격 활성화 되어있을 시 우측 발사 및 발사 제한 걸기
            if (isRAttack == true)
            {
                GameObject A = Instantiate(RBullet);

                A.transform.position = RPos.transform.position;
                A.transform.rotation = RPos.transform.rotation;
                isRAttack = false;
                GM.RTime = 10.0f;
            }
            //좌측 공격 활성화 되어있을 시 좌측 발사 및 발사 제한 걸기
            else if (isLAttack == true)
            {
                GameObject B = Instantiate(LBullet);

                B.transform.position = LPos.transform.position;
                B.transform.rotation = LPos.transform.rotation;
                isLAttack = false;
                GM.LTime = 10.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(isRepair == true && GM.hp < 10)
            {
                GM.hp++;
                isRepair = false;
                Repair.Play();
                GM.ReTime = 15.0f;
                RepairTime = 0.0f;
            }
            
        }
        if(isRepair == false)
        {
            RepairTime += Time.deltaTime;
            if(RepairTime >= MaxRepairtime)
            {
                isRepair = true;
                
            }
        }
    }
}
