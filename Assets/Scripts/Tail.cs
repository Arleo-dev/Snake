using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : Player
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _body;
    private List<Transform> snakeBody = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    private float targetDistance = 0.3f;

    private void Start()
    {
        positions.Add(_target.position);
    }
    private void Update()
    {
        float dictance = (_target.position - positions[0]).magnitude;

        if (dictance > targetDistance)
        {
            Vector3 direction = (_target.position - positions[0]).normalized;
            positions.Insert(0, positions[0] + direction * targetDistance);
            positions.RemoveAt(positions.Count - 1);
            dictance -= targetDistance;
        }
        for (int i = 0; i < snakeBody.Count; i++)
        {
            snakeBody[i].position = Vector3.Lerp(positions[i + 1], positions[i], dictance / targetDistance);
        }
    }
    public void AddBody()
    {
        Transform body = Instantiate(_body, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeBody.Add(body);
        positions.Add(body.position);
    }
}
