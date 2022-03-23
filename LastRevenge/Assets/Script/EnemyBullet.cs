using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float AttackSpeed = 0.5f;
    GameObject PC;

    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("Player");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackSpeed <= 20)
        {
            AttackSpeed += Time.deltaTime / 4;
        }

        //오브젝트 이동
        //transform.position +=  Vector3.forward * AttackSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * AttackSpeed);

        Invoke("destroy", 5.0f);
       
    }

    void destroy()
    {
        AttackSpeed = 0.5f;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GM.hp--;
            AttackSpeed = 0.5f;
            Destroy(gameObject);
        }
    }
}
