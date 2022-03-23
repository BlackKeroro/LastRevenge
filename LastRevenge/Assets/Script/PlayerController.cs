using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float UpDownSpeed;
    public float turnSpeed;

    float MouseOriginPosX;
    float MouseOriginPosY;

    public float Radious;

    public ParticleSystem PC;
    public Transform ParticlePos;

    public static bool isLoad = false ; //¿ÀÇÁ´× ½ºÅµ 

    // Start is called before the first frame update
    void Start()
    {
        MouseOriginPosX = Input.mousePosition.x;
        MouseOriginPosY = Input.mousePosition.y;
        PC.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Camera.main.transform.rotation * Vector3.forward * MoveSpeed * Time.deltaTime;
        PC.transform.position = ParticlePos.transform.position;
        Move();

        Rote();

    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W) && MoveSpeed <= 15.0f)
        {
            MoveSpeed += Time.deltaTime * 6;
            PC.Play();
            
        }
        else if (MoveSpeed <= 0)
        {
            MoveSpeed = 0.0f;
            PC.Stop();
        }
        else if(Input.GetKey(KeyCode.S) && MoveSpeed > 0)
        {
            MoveSpeed -= Time.deltaTime * 2;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * UpDownSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            transform.position += Vector3.down * UpDownSpeed * Time.deltaTime;
        }

        if(transform.position.y > 2.0f)
        {
            Vector3 vec = new Vector3(transform.position.x, 2.0f, transform.position.z);
            transform.position = vec;

        }
    }

    public float rotX;
    public float rotY;

    void Rote()
    {
        float X = Input.mousePosition.x - MouseOriginPosX;
        float Y = Input.mousePosition.y - MouseOriginPosY;

        if (X >= 300.0f)
        {
            X = 300.0f;
        }
        else if (X <= -300.0f)
        {
            X = -300.0f;
        }
        if(Y >= 300)
        {
            Y = 300.0f;
        }
        else if(Y <= -300)
        {
            Y = -300.0f;
        }



        if (X > 100)
        {
            rotX += turnSpeed * Time.deltaTime;

        }
        else if (X < -100)
        {
            rotX -= turnSpeed * Time.deltaTime;
        }
        

        if (Y > 100)
        {
            rotY += turnSpeed * Time.deltaTime;
        }
        else if (Y < -100)
        {
            rotY -= turnSpeed * Time.deltaTime;
        }



        /*        transform.Rotate(0f, Input.GetAxis("Mouse X") * turnSpeed, 0f);
                transform.Rotate(-Input.GetAxis("Mouse Y") * turnSpeed, 0f, 0f);*/

        Vector3 vec = new Vector3(-rotY, rotX, 0.0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(vec), 5f);
        //Debug.Log(X);
        


    }


}
