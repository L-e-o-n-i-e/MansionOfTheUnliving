using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<CheckPoint> CheckPoints = new List<CheckPoint>();
    


    public void Connect()
    {
        PlayerManager.Instance.playerPrefab = playerPrefab;

        CheckPointManager.Instance.list = CheckPoints;
    }
}
