using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Range(0f, 50f)]
    public float rotAngle = 20f;


    public override void OnCollisionExit(Collision otherOb)
    {
        base.Update();
        TweakDir();
    }

    private void TweakDir()
    {
        float yDir = transform.rotation.eulerAngles.y; //Only this euler gets the real rot position
        float setOffset = Random.Range(yDir - rotAngle, yDir + rotAngle); // Off set the current angle
        transform.rotation = Quaternion.Euler(transform.rotation.x, setOffset , transform.rotation.z);
    }
}
