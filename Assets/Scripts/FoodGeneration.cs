using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _foodPref;
    private GameObject _food;
    private Vector3 _curPos;
    private void AddNewFood()
    {
        RandPos();
        _food = GameObject.Instantiate(_foodPref, _curPos, Quaternion.identity) as GameObject;
    }
    private void RandPos()
    {
        _curPos = new Vector3(Random.Range(-9f, 9f), 0.5f, Random.Range(-9f, 9f));    
    }
    
    private void Update()
    {
        if (!_food)
        {
            AddNewFood();
        }
    }
}
