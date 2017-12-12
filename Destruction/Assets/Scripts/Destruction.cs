﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    [Header("Game Objects")]
    [Space(2)]
    public GameObject brokenObj;
    public GameObject togetherObj;

    [Space(7)]
    [Header("State")]
    [Space(2)]
    // True if together, false if broken
    public bool together = true;

    [Space(7)]
    [Header("Breaking on Collision")]
    [Space(2)]
    public bool breakOnCollision = true;
    public float velocityToBreak = 1;


    // Use this for initialization
    void Start () {
        togetherObj.SetActive(true);
        brokenObj.SetActive(false);
    }
	
    // Update is called once per frame
    void Update () {
        togetherObj.SetActive(together);
        brokenObj.SetActive(!together);
    }

    void OnCollisionEnter(Collision collision) {
        if (!breakOnCollision)
            return;
        if (collision.relativeVelocity.magnitude > velocityToBreak)
            Break();
    }

    public void Break () {
        together = false;
    }

    public void BreakWithExplosiveForce(float force, float radius = 3) {
        Break();
        foreach (Rigidbody rigid in brokenObj.GetComponentsInChildren<Rigidbody>()) {
            rigid.AddExplosionForce(force, transform.position, radius);
        }
    }

}
