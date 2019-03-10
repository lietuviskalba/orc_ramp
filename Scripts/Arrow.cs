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
            GameObject gm = GameObject.FindGameObjectWithTag("Master");
            gm.GetComponent<GameMaster>().IncEnemyGS--;
            gm.GetComponent<Score>().IncScoreGS++;
            Destroy(other);
            Destroy(gameObject); //Destoy this always last (so that the rest code executes
        }
    }
}
