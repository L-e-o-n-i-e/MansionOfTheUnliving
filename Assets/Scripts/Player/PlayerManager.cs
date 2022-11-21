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

    #region Timers
    private float timeToStop;
    private float timeBeforeStop = 5;
    private float timeToLeaveCheckPoint;
    private float timeBeforeLeaving = 2;
    #endregion
    public GameObject playerPrefab;
    private Player player;

    private Vector3 START_POSITION = new Vector3(-9, 1, 10);
    public int START_HP = 3;
    public int START_AMMO = 5;

    public bool hasArrived = false;
    public bool exitCheckPoint = false;
    public bool playerDied = false;
    
      public void PreInitialize()
    {
        timeToStop = Time.time + timeBeforeStop;
        SpawnPlayer();
        Transform target = CheckPointManager.Instance.GetTransformCheckPoint();
        player.MoveTowards(target);
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {
        if (!playerDied)
        {
            //Get to CheckPoint
            if (hasArrived == true)
            {
                EnemyManager.Instance.playerHasArrived = true;
                player.action = true;
            }

            //Leave CheckPoint
            if (Time.time >= timeToLeaveCheckPoint)
            {
                hasArrived = false;
                Transform target = CheckPointManager.Instance.GetTransformCheckPoint();
                player.MoveTowards(target);
            }
        }

    }

    public void PhysicsRefresh()
    {
    }

    public void EndGame()
    {
    }

    public void SpawnPlayer()
    {
        GameObject playerToClone = GameObject.Instantiate<GameObject>(playerPrefab);
        player = playerToClone.GetComponent<Player>();
        player.transform.position = START_POSITION;
    }

    public Transform GetPlayerTransform()
    {
        return player.transform;
    }

    public void WaitingBeforeLeaving()
    {
        timeToLeaveCheckPoint = Time.time + timeBeforeLeaving;
    }

}
