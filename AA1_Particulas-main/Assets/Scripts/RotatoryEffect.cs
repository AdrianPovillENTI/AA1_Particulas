using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoryEffect : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    private void FixedUpdate ( )
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
