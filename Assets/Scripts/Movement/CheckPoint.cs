using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int nbZombies = 3;
    public int nbBreakdancers = 1;
    bool arrived = false;

    public void MoveToCheckPoint(Transform camPosition)
    {
        while (!arrived)
        {
            //Timer to lerp from current player position to checkpoint position

        }
    }
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
}
