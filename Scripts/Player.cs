using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject ammo;
    public GameObject bag;

    [Range(0f, 15f)]
    [Tooltip("How fast player makes turns")]
    public float rotSpeed;
    [Range(0f, 25f)]
    public float fireRate = 5f;
    [Range(0f, 25f)]
    public float bagSpawnRate = 5f;

    public bool isArrowShooting;

    private float nextShot = 1f;
    private float nextBagSpawn = 1f;

    public bool IsBagPressedGS { get; set; } = false;

    public override void Update()
    {
        base.Update();
        RotateDir();
        ShootArrow();
        SpawnBag();
    }

    private void RotateDir()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -1f * rotSpeed, 0f, Space.Self);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 1f * rotSpeed, 0f, Space.Self);
        }
    }

    private void SpawnBag()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextBagSpawn)
        {
            IsBagPressedGS = true;
            nextBagSpawn = Time.time + bagSpawnRate; // Limite bag spawm spawn

            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.forward;
            float spawnDistance = 4f;

            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

            GameObject cloneBag = Instantiate(bag, spawnPos, transform.rotation) as GameObject;
            Destroy(cloneBag, 1f); //Destroy after being placed.
        }

        IsBagPressedGS = false;
    }

    private void ShootArrow()
    {
        if (Time.time > nextShot && isArrowShooting == true)
        {
            nextShot = Time.time + fireRate;
            Instantiate(ammo, transform.position, transform.rotation);
        }
    }
}
