using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    void Start()
    {
        Singleton.Instance.IncreaseScore(10);
        GameManager.Instance.IncreaseScore(15);
    }

    void Update()
    {
        
    }
}
