using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyMove : MonoBehaviour
{
    Transform target;
    float enemyMoveSpeed = 8f;
    float RotSpeed = 1f;

    // Start is called before the first frame update
    public void Start()
    {
        InvokeRepeating("UpdataTarget", 0f, 0.25f);
    }

    public void UpdataTarget()
    {
       Collider[] cols = Physics.OverlapSphere(transform.position, 60f);
        
        if(cols.Length > 0)
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
        if(target != null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * enemyMoveSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime* RotSpeed);
        }
    }
    public  void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 60f);
    }
}
