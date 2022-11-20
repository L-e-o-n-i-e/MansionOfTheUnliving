using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : IFlow
{
    #region Singleton
    //SINGLETON! REMOVE MONOBEHAVIOR
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
                instance = new EnemyManager();

            return instance;
        }

    }
    private EnemyManager() { }
    #endregion


    List<Enemy> enemies = new List<Enemy>();

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
 
    public void OnEnterCheckPoint()
    {

    }
    public void OnUpdateCheckPoint()
    {

    } 

    public void OnExitCheckPoint()
    {

    }

}
