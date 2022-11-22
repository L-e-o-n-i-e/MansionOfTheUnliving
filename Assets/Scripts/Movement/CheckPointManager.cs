using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHeckPointPhase { Moving, GetInPosition, Spawning, Action, WaitingBreforeLeaving}
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
    public CHeckPointPhase phase = CHeckPointPhase.Moving;

    public void PreInitialize()
    {
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {
        switch (phase)
        {
            case CHeckPointPhase.Moving:

                break;
            case CHeckPointPhase.GetInPosition:

                break;
            case CHeckPointPhase.Spawning:

                break;
            case CHeckPointPhase.Action:
                break;
            case CHeckPointPhase.WaitingBreforeLeaving:
                break;
            default:
                break;
        }

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
        Debug.Log("checkpoint # :" + indexCurrentCheckPoint);

        if (indexCurrentCheckPoint == list.Count - 1)
        {
            LevelFinished();
        }
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

    public CHeckPointPhase GetCheckPointPhase()
    {
        return phase;
    }
}
