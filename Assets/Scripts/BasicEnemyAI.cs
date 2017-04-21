using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : EnemyBase
{

    void Start()
    {
        base.Start();
        checkScore(5, true);
    }

    void Update()
    {
        base.Update();
    }


}
