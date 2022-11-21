using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : IFlow
{
    #region Singleton
    //SINGLETON! REMOVE MONOBEHAVIOR
    private static CheckPointManager instance;
    public static CheckPointManager Instance
    {
        get
        {
            if (instance == null)
                instance = new CheckPointManager();

            return instance;
        }

    }
    private CheckPointManager() { }
    #endregion

    GameObject checkPoint;
    public List<CheckPoint> list = new List<CheckPoint>();
    int indexCurrentCheckPoint = 0;

    public void PreInitialize()
    {
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {

    }

    public void PhysicsRefresh()
    {
    }

    public void EndGame()
    {
    }

    public void GoToNextCheckPoint()
    {
        indexCurrentCheckPoint++;

        if (indexCurrentCheckPoint == list.Count - 1)
        {
            LevelFinished();
        }

        PlayerManager.Instance.WaitingBeforeLeaving();

    }

    public void LevelFinished()
    {

    }

    public Transform GetTransformCheckPoint()
    {
        return list[indexCurrentCheckPoint].transform;
    }

    public void GetNbEnemiesToSpawn(out int nbZombies, out int nbBreakDancers, out Transform spawnArea)
    {
        nbBreakDancers = list[indexCurrentCheckPoint].nbBreakdancers;
        nbZombies = list[indexCurrentCheckPoint].nbZombies;
        spawnArea = list[indexCurrentCheckPoint].transform.GetChild(0);
    }
}
