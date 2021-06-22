using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float speed = 2f;
    private float rotatioSpeed = 360f;
    private const string LevelName = "GameOver";
    private Transform _transform;
    private Animation anim;
    [SerializeField] private UnityEvent OnEat;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotatioSpeed * Time.deltaTime * horizontal, 0);
        transform.position = _transform.position + _transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Food>())
        {
            speed += 0.1f;
            if(OnEat != null)
            {
                OnEat.Invoke();
            }
        }
        else if (other.GetComponent<CameraSwitch>())
        {
            return;
        }
        else
        {
            Application.LoadLevel(LevelName);
        }
    }
}