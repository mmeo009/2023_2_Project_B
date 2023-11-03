using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownTower : MonoBehaviour
{
    private Tower thisTower;

    void Start()
    {
        thisTower = GetComponent<Tower>();
    }
    void Update()
    {
        if(thisTower.enemiesUpdate)
        {
            if(thisTower.enemiesinRange.Count > 0)
            {
                foreach(EnemyController enemy in thisTower.enemiesinRange)
                {
                    enemy.SetMode(thisTower.fireRate);
                }
            }
        }
    }
}
