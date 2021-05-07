using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    [SerializeField] private GameObject foodPref;
    private GameObject food;
    private Vector3 curPos;
    private void AddNewFood()
    {
        RandPos();
        food = GameObject.Instantiate(foodPref, curPos, Quaternion.identity) as GameObject;
    }
    private void RandPos()
    {
        curPos = new Vector3(Random.Range(-9f, 9f), 0.5f, Random.Range(-9f, 9f));    
    }
    
    private void Update()
    {
        if (!food)
        {
            AddNewFood();
        }
    }
}
