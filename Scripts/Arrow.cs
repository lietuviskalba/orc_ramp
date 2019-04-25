using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Range(-10f, 20f)]
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider coll)
    {
        GameObject other = coll.gameObject;
        if (other.tag.Equals("Wall") || other.tag.Equals("Spawner")) // Arrow breaks after hitting a wall.
        {
            Destroy(gameObject);
        }

        if (other.tag.Equals("Enemy")) // Kill enemy
        {
            GameObject gm = GameObject.FindGameObjectWithTag("Master");
            gm.GetComponent<GameMaster>().IncEnemyGS--;
            gm.GetComponent<Score>().IncScoreGS++;
            Destroy(other);
            Destroy(gameObject); // Destoy this always last (so that the rest code executes
        }
    }
}
