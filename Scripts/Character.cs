using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [Range(-10f,15f)]
    public float speed = 5f;
    [Range(0f, 15f)]
    public float rotSpeed;

    //god mode
    public bool isMoving = true;

    void Update()
    {
        RotateDir();
        MoveForward();
    }

    private void RotateDir()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f,-1f * rotSpeed, 0f, Space.Self);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 1f * rotSpeed, 0f, Space.Self);
        }
    }

    public void MoveForward()
    {
        if (isMoving == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision otherOb)
    {
        if (otherOb.gameObject.tag.Equals("Wall"))
        {
            transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;


        }
    }
}
