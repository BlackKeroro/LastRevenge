using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGene : MonoBehaviour
{
    float currentTime;
    public float GenTime;

    public int num; //최대 숫자
    public int count;

    public GameObject GenEnemy;
    public GameObject[] Pos;
    GameObject rnd; // 랜덤 변수
    public List<GameObject> EnemyList = new List<GameObject>();

    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(count < num)
        {
            currentTime += Time.deltaTime;
        }
        if(currentTime > GenTime)
        {
            rnd = Pos[Random.Range(0, Pos.Length)];
            GameObject A = Instantiate(GenEnemy) as GameObject;
            A.transform.position = rnd.transform.position;
            EnemyList.Add(A);
            currentTime = 0.0f;
            count++;
        }
    }
}
