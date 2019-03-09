using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Range(-10f, 20f)]
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider coll)
    {
        GameObject other = coll.gameObject;
        if (other.tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.tag.Equals("Enemy"))
        {
            //Add point here
            GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>().IncEnemyGS--;
            Destroy(other);
            Destroy(gameObject);
        }
    }
}
