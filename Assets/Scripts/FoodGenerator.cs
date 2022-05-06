using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    private float xSize = 0f;
    private float zSize = 0f;
    private const float yPos = 0.5f;
    [SerializeField] private GameObject _floorToGenerator;
    [SerializeField] private GameObject _foodPref;
    private GameObject _food;
    private Vector3 _curPos;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        xSize = _floorToGenerator.GetComponent<BoxCollider>().size.x / 2;
        zSize = _floorToGenerator.GetComponent<BoxCollider>().size.z / 2;
    }
    private void Update()
    {
        if (!_food)
        {
            AddNewFood();
        }
    }
    private void AddNewFood()
    {
        RandPos();
        _food = GameObject.Instantiate(_foodPref, _curPos, Quaternion.identity);
    }
    private void RandPos()
    {
        _curPos = new Vector3(Random.Range(xSize, -xSize), yPos / 0.7f, Random.Range(zSize, -zSize));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Food>())
        {
            Destroy(_food);
            Debug.Log(other.gameObject.name);
            RandPos();
        }
        else
        {
            AddNewFood();
        }

    }

}
