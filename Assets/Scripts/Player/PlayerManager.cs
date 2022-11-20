using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : IFlow
{
    #region Singleton
    //SINGLETON! REMOVE MONOBEHAVIOR
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerManager();

            return instance;
        }

    }
    private PlayerManager() { }
    #endregion

    Player player; 

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
