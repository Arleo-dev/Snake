using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelByTimer : MonoBehaviour
{
    private float delay = 3f;
    private const string LevelName = "Menu";
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        Application.LoadLevel(LevelName);
    }
}
