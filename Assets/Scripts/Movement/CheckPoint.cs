using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int nbZombies = 2;
    public int nbBreakdancers = 1;
    bool arrived = false;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player is on checkPoint");
        if (other.transform.tag == "Player")
        {
            arrived = true;
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
