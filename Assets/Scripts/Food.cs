using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider _playerCheck)
    {
        if (_playerCheck.GetComponent<Player>())
        {
            _playerCheck.GetComponent<Tail>().AddBody();
            Destroy(gameObject);
            Debug.Log("Point");
        }
    }
}
