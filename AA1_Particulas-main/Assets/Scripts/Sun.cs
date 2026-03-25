using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Planeta
{
    [SerializeField] private Planeta[] planetas;

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(Planeta planet in planetas)
        {
            planet.UpdateVel(this);
            planet.UpdatePos();
        }
    }
}
