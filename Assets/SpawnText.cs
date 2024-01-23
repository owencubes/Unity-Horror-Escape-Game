using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject txt; 
    float duration = 3f;
    void Start()
    {
        StartCoroutine(TestRoutine(duration));
    }

    IEnumerator TestRoutine(float duration)
    {
        txt.SetActive(true);
        yield return new WaitForSeconds(duration);
        txt.SetActive(false);
    }

    
}
