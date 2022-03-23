using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullGen : MonoBehaviour
{

    float currentTime;
    public float AttackTime;

    public GameObject Attack;
    GameObject PC;
    public Transform Pos;

    PlayerController player;
    EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("Player");
        player = PC.GetComponent<PlayerController>();
        enemy = GetComponent<EnemyController>();

    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (currentTime > AttackTime)
        {
            GameObject A = Instantiate(Attack);
            A.transform.position = Pos.transform.position;
            A.transform.rotation = Pos.transform.rotation;
            currentTime = 0.0f;
        }
    }


}
