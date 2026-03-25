using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    public float mass;
    private Vector3 currentVelocity;

    public void CalculateInitialVelocity(float otherMass, Vector3 otherPos)
    {
        // 1st we need the distance between both celestial bodies
        float distance = (otherPos - transform.position).magnitude;
        // Then we calculate the velocity with the formula
        float initialVelocity = Mathf.Sqrt(UniversalConst.gravitationalConstant * otherMass / distance);
        // Finally we add the velocity to z coordinate so the planet start moving in a direction perpendicular to the sun
        currentVelocity = new Vector3(0.0f, 0.0f, initialVelocity);
    }
        

    public void UpdateVel(Planeta other)
    {
        // Calculate the square of the distance between both planets
        float sqrDist = (other.transform.position - transform.position).sqrMagnitude;

        // Calculate the force direction
        Vector3 forceDir = (other.transform.position - transform.position).normalized;

        // Calculate the gravitational force between both planets usint the universal gravitational law
        Vector3 force = forceDir * (UniversalConst.gravitationalConstant * mass * other.mass / sqrDist);

        // Calculate the acceleration
        Vector3 acceleration = force / mass;

        currentVelocity += acceleration * UniversalConst.physicsTimeStep;
    }
    
    public void UpdatePos()
    {
        transform.position += currentVelocity * UniversalConst.physicsTimeStep;
    }
}
