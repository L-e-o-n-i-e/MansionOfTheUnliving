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

    bool hasArrived = false;
    bool exitCheckPoint = false;
    
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
        player.Update();

        //MovingState

        //if (!hasArrived)
        //{
        //    Vector3 target = CheckPointManager.Instance.GetTargetCheckPoint();
        //    MoveToCheckPoint(target);
        //}
        
        
        //else if (Time.time >= timeToStop)
        //{
        //    hasArrived = true;
        //}

        //TransitionToAction

        //Action
        player.Update();
        //if all enemies are dead : exitCheckPoint =  true;

        //WaitingBeforeLeaving
        if (exitCheckPoint) {
            timeToLeaveCheckPoint = Time.time + timeBeforeLeaving;
        }
        // hasArrived = false; 

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

    public void SpawnPlayer()
    {
        GameObject playerToClone = GameObject.Instantiate<GameObject>(playerPrefab);
        player = playerToClone.GetComponent<Player>();
        player.transform.position = START_POSITION;
    }

    public void MoveToCheckPoint(Vector3 TargetPos)
    {
        if (Time.time < timeToStop)
        {
            while (player.transform.position != TargetPos)
            {
                //Timer to lerp from current player position to checkpoint position
                
                //Move the player to make him face that way
                //(B - A).normalized * speed;
                //NavMesh is a good strategy

            }
        }
    }

}
