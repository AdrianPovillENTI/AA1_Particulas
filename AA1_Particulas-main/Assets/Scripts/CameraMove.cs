using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform[] planetCameraTransform;
    private Transform originalTransform;
    private Transform currentTransform;
    private int currentPlanetIndex = 0;
    private void Start ( )
    {
        originalTransform = transform;
        currentTransform = transform;
    }
    private void Update ( )
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(PerformMovement(++currentPlanetIndex));
            SwitchCamera();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(PerformMovement(--currentPlanetIndex));
            SwitchCamera();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(PerformMovement(++currentPlanetIndex));
            SwitchCamera();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(PerformMovement(--currentPlanetIndex));
            SwitchCamera();
        }
    }
    private void NextPosition ( )
    {
        currentTransform.position = Vector3.Lerp(currentTransform.position, planetCameraTransform[currentPlanetIndex].position, Time.deltaTime);
        currentTransform.rotation = Quaternion.Lerp(currentTransform.rotation, planetCameraTransform[currentPlanetIndex].rotation, Time.deltaTime);
        currentTransform.localScale = Vector3.Lerp(currentTransform.localScale, planetCameraTransform[currentPlanetIndex].localScale, Time.deltaTime);
    }
    private void SwitchCamera ( )
    {

        if (currentPlanetIndex > planetCameraTransform.Length - 1)
        {
            currentPlanetIndex = 0;
        }
        else if (currentPlanetIndex < 0)
        {
            currentPlanetIndex = planetCameraTransform.Length - 1;
        }

        if (gameObject.GetComponent<Camera>().isActiveAndEnabled)
        {
            gameObject.GetComponent<Camera>().enabled = false;
        }
        currentTransform.GetComponent<Camera>().enabled = false;
        planetCameraTransform[currentPlanetIndex].GetComponent<Camera>().enabled = true;
        Debug.Log("Camera switched to " + planetCameraTransform[currentPlanetIndex].name);
        currentTransform = planetCameraTransform[currentPlanetIndex];
    }
    private IEnumerator PerformMovement ( int index )
    {
        currentPlanetIndex = index;
        while (Vector3.Distance(currentTransform.position, planetCameraTransform[currentPlanetIndex].position) >= 0.0001f)
        {
            NextPosition();
            yield return null;
        }

        if (currentPlanetIndex > planetCameraTransform.Length - 1)
        {
            currentPlanetIndex = 0;
        }
        else if (currentPlanetIndex < 0)
        {
            currentPlanetIndex = planetCameraTransform.Length - 1;
        }
    }
}
