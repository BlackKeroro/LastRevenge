using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform target;
    float enemyMoveSpeed = 8f;
    float RotSpeed = 1f;

    public float currentTime;
    public float AttackTime;
    public float WaitTime;
    public float DTime;

    public GameObject Attack;
    GameObject PC;
    public Transform Pos;

    public int Hp = 2;
    public ParticleSystem PS;

    GameManager GM;
    EnemyGene EG;

    float TRange = 20.0f;
    float PRange = 20.0f;
    GameObject player;

    bool isScore = true;
    // Start is called before the first frame update
    public void Start()
    {
        InvokeRepeating("UpdataTarget", 0f, 0.25f);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        EG = GameObject.Find("GameManager").GetComponent<EnemyGene>();
        PS.Pause();
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    public void UpdataTarget()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 80f);

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == "Player")
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
        if(Hp > 0)
        {
            WaitTime += Time.deltaTime;
            if (target != null)
            {
                Vector3 Coin = transform.position;
                Vector3 Player = this.player.transform.position;
                Vector3 Run = Coin - Player;
                float Range = Run.magnitude;

                currentTime += Time.deltaTime;

                if (currentTime > AttackTime)
                {
                    GameObject A = Instantiate(Attack);
                    A.transform.position = Pos.transform.position;
                    A.transform.rotation = Pos.transform.rotation;
                    currentTime = 0.0f;
                }

                if (Range > TRange + PRange)
                {
                    Vector3 dir = target.position - transform.position;
                    transform.Translate(-dir.normalized * enemyMoveSpeed * Time.deltaTime);
                    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * RotSpeed);
                }
            }
        }

        if(transform.position.y > 1.0f)
        {
            Vector3 vec = new Vector3(transform.position.x, 1.0f, transform.position.z);
            transform.position = vec;
        }


        if(Hp == 1)
        {
            PS.Play();
        }
        if(Hp <= 0)
        {
            
            WaitTime = 0.0f;
            Vector3 Dposition = new Vector3(0, -0.07f, 0);
            transform.Translate(Dposition);
            GetComponent<BoxCollider>().enabled = false;
            gameObject.tag = "Destroy";
            Invoke("DT", 3f);
        }
        if(WaitTime > DTime)
        { 
            WaitTime = 0.0f;
            Destroy(gameObject);
        }
        
    }
    void DT()
    {
        if(isScore == true)
        {
            EG.count--;
            Destroy(gameObject);
            GM.Score++;
            isScore = false;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 80f); 
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GM.hp--;
        }
    }
}

