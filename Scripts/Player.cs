using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject ammo;
    public GameObject bag;

    [Range(-5f, 25f)]
    public float fireRate = 5f;
    [Range(-5f, 25f)]
    public float bagSpawnRate = 5f;

    private float nextShot = 1f;
    private float nextBagSpawn = 1f;

    public override void Update()
    {
        base.Update();
        ShootArrow();
        SpawnBag();
    }

    private void SpawnBag()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextBagSpawn)
        {
            nextBagSpawn = Time.time + bagSpawnRate; // limite bag spam spawn

            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.forward;
            float spawnDistance = 4f;

            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

            GameObject cloneBag = Instantiate(bag, spawnPos, transform.rotation) as GameObject;
            Destroy(cloneBag, 1f); //Destroy after being placed
        }
    }

    private void ShootArrow()
    {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + fireRate;
            Instantiate(ammo, transform.position, transform.rotation);
        }
    }
}
