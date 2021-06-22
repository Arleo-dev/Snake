using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private void Start()
    {
        _camera.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _camera.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _camera.enabled = false;
        }
    }
}
