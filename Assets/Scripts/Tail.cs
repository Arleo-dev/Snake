using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _body;
    private List<Transform> snakeBody = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    private List<Quaternion> rotations = new List<Quaternion>();
    private float targetDistance = 0.4f;

    private void Start()
    {
        positions.Add(_target.position);
        rotations.Add(_target.rotation);
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
        if(snakeBody.Count > 0)
           snakeBody[snakeBody.Count - 1].rotation = _target.rotation;
        
    }
    public void AddBody()
    {
        Transform body = Instantiate(_body, positions[positions.Count - 1], rotations[0], transform);
        snakeBody.Add(body);
        positions.Add(body.position);
        rotations.Add(body.rotation);
    }
}
