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
    Transform camPos;
    List<CheckPoint> list = new List<CheckPoint>();
    int indexCurrentCheckPoint = 0;

    public void PreInitialize()
    {
        camPos = Camera.main.transform;

        int nbOfChild = checkPoint.transform.childCount;

        for (int i = 0; i < nbOfChild; i++)
        {
            CheckPoint cp = checkPoint.transform.GetComponentInChildren<CheckPoint>();
            list.Add(cp);
        }
    }

    public void Initialize()
    {
        list[indexCurrentCheckPoint].MoveToCheckPoint(camPos);
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
        list[indexCurrentCheckPoint].MoveToCheckPoint(camPos);

        if (indexCurrentCheckPoint == list.Count - 1)
        {
            LevelFinished();
        }

    }

    public void LevelFinished()
    {

    }
}
