using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _score;
    private float speed = 2f;
    private float rotatioSpeed = 360f;
    private const string LevelName = "GameOver";
    private Transform _transform;

    [SerializeField] private UnityEvent OnEat;
    [SerializeField] private Text _textScore;

    private void Start()
    {
        _textScore.text = "Score: 0";
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
            _score += 1;
            _textScore.text = $"Score: {_score}"; 
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