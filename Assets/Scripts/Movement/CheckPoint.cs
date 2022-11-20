using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int nbZombies = 3;
    public int nbBreakdancers = 1;
    bool arrived = false;
    Transform spawnArea;

    
    public void ArrivedAtCheckPoint()
    {
        arrived = true;
    }

    public void BattleAtCheckPoint()
    {

    }

    public void LeaveCheckPoint()
    {
        arrived = false;
    }


    public Transform getSpawnArea()
    {
        return spawnArea;
    }
}
