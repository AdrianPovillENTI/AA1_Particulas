using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    public float mass;
    public Vector3 initialVelocity;
    Vector3 currentVelocity;

    void Awake()
    {
        currentVelocity = initialVelocity;
        //rb = GetComponent<Rigidbody>();
    }

    public void UpdateVel(Planeta other)
    {
        // Calculate the square of the distance between both planets
        float sqrDist = (other.transform.position - transform.position).sqrMagnitude;
        Debug.Log("sqr dis" + sqrDist);
        // Calculate the force direction
        Vector3 forceDir = (other.transform.position - transform.position).normalized;
        Debug.Log("Force dir = " + forceDir);
        // Calculate the gravitational force between both planets usint the universal gravitational law
        Vector3 force = forceDir * (UniversalConst.gravitationalConstant * mass * other.mass / sqrDist);
        // Calculate the acceleration
        Vector3 acceleration = force / mass;
        Debug.Log("Force = " + force.magnitude);
        Debug.Log("accel = " + acceleration);
        currentVelocity += acceleration * UniversalConst.physicsTimeStep;
    }
    
    public void UpdatePos()
    {
        transform.position += currentVelocity * UniversalConst.physicsTimeStep;
    }
}
