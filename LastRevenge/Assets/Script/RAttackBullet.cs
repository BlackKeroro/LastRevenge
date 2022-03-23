using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAttackBullet : MonoBehaviour
{

    Transform target;
    float enemyMoveSpeed = 8f;
    float RotSpeed = 10f;

    float AttackSpeed = 0.0f; //������Ʈ �߻� �ӵ�
    
    GameObject Generator; //������ ������Ʈ �޾ƿ���
    AttackGene AG; 

    float currentTime = 0.0f; //���� �ð� �� ������Ʈ ���� ����


    public ParticleSystem PS;
    public GameObject Attack;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdataTarget", 0f, 0.20f);

        Generator = GameObject.Find("Player"); //�÷��̾� ������Ʈ ã��
        AG = Generator.GetComponent<AttackGene>(); //������Ʈ �޾ƿ���
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

        // �߻� �ӵ� ����
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
        //������Ʈ �̵�
        //���� �ð� �� ������Ʈ ����
        currentTime += Time.deltaTime;
        if (currentTime >= 10.0f)
        {
            AttackSpeed = 0.0f;
            currentTime = 0.0f;
            Destroy(gameObject);
            AG.isRAttack = true;   //���� ���� Ȱ��ȭ
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
