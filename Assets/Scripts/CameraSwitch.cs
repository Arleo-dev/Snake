using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _point;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _camera.transform.position = _point.transform.position;
        }
    }
}
