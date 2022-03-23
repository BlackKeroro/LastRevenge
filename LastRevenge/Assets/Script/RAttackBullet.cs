using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAttackBullet : MonoBehaviour
{

    Transform target;
    float enemyMoveSpeed = 8f;
    float RotSpeed = 10f;

    float AttackSpeed = 0.0f; //오브젝트 발사 속도
    
    GameObject Generator; //프리팹 오브젝트 받아오기
    AttackGene AG; 

    float currentTime = 0.0f; //일정 시간 뒤 오브젝트 제거 변수


    public ParticleSystem PS;
    public GameObject Attack;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdataTarget", 0f, 0.20f);

        Generator = GameObject.Find("Player"); //플레이어 오브젝트 찾기
        AG = Generator.GetComponent<AttackGene>(); //컴포넌트 받아오기
    }

    public void UpdataTarget()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 40f);

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == "Enemy")
                {
                    Debug.Log("Attack");
                    target = cols[i].gameObject.transform;
                }
            }

        }
        else
        {
            Debug.Log("Lost");
            target = null;
        }
    }
    // Update is called once per frame
    public void Update()
    {


        transform.Translate(Vector3.forward * AttackSpeed);

        // 발사 속도 제한
        if (AttackSpeed <= 30)
        {
            AttackSpeed += Time.deltaTime / 2;
        }
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
/*            transform.Translate(dir.normalized * AttackSpeed);
*/            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * RotSpeed);
        }
        //오브젝트 이동
        //일정 시간 뒤 오브젝트 삭제
        currentTime += Time.deltaTime;
        if (currentTime >= 10.0f)
        {
            AttackSpeed = 0.0f;
            currentTime = 0.0f;
            Destroy(gameObject);
            AG.isRAttack = true;   //우측 공격 활성화
        }


    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Instantiate(Attack, transform.position, transform.rotation);
            Instantiate(PS, transform.position, transform.rotation);
            AttackSpeed = 0.0f;
            AG.isRAttack = true;
            currentTime = 0.0f;
            Destroy(gameObject);
            coll.GetComponent<EnemyController>().Hp--;
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 40f);
    }



}
