using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject food;
    private float speed = 2f;
    private float rotatioSpeed = 360;
    private const string LevelName = "GameOver";
    private Transform _transform;
    private Tail tail;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        tail = GetComponent<Tail>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotatioSpeed * Time.deltaTime * horizontal, 0);
        transform.position = _transform.position + _transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.GetComponent<Food>())
        {
            speed += 0.1f;
        }
        else
        {
            Application.LoadLevel(LevelName);
        }


    }
}