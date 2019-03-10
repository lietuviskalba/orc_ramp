using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [Range(-10f,15f)]
    public float speed = 5f;
    private  float distToGround;
    private float timeStuck;
    public float stuckTreshold = 5f;
    public bool isMoving = true;

    private void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    public virtual void Update()
    {
        MoveForward();
    }

    public void MoveForward()
    {
        if (IsGrounded())
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision coll)
    {
        GameObject otherOb = coll.gameObject;
        if (otherOb.tag.Equals("Wall") || otherOb.tag.Equals("Enemy") || otherOb.tag.Equals("Spawner")) //When hit into objects
        {
            transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation; //Epick code
        }

        if (gameObject.tag.Equals("Enemy") && otherOb.tag.Equals("Player")) //When player gets killed by enemy
        {
            GameOver(otherOb);
        }
    }

    private static void GameOver(GameObject otherOb)
    {
        otherOb.gameObject.SetActive(false);
        LevelManager lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        lm.LoadScene("end_game");
    }

    private void OnCollisionStay(Collision otherOb)
    {
        if (otherOb.gameObject.tag.Equals("Wall"))
        {
            IsItStuck();
        }
    }

    private void IsItStuck()
    {
        timeStuck -= Time.deltaTime; // timer for getting stuck

        if (timeStuck <= 0)
        {
            //!!! Maybe make better code to resolve stuck enemies
            Debug.LogWarning("Enemy got stuck. So it got its pos reseted!");
            transform.position = new Vector3(0f, 5f, 0f);
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f); // Epick code
    }

    public virtual void OnCollisionExit(Collision otherOb)
    {
        timeStuck = stuckTreshold; // Reset the timer if not stuck
    }
}
