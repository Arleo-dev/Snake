using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private float speed = 2f;
    private float rotatioSpeed = 360;
    private CharacterController _controller;
    public GameObject food;
    private Tail tail;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotatioSpeed * Time.deltaTime * horizontal, 0);
        _controller.Move(transform.forward * speed * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject != food)
        {
            Application.LoadLevel("GameOver");
        }
    }
}
