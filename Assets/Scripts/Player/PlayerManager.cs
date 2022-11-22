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
    public bool targetAssigned = false;
    public bool playerDied = false;
    public bool checkPointAssigned = false;

    public void PreInitialize()
    {
        timeToStop = Time.time + timeBeforeStop;
        SpawnPlayer();
        //Transform target = CheckPointManager.Instance.GetTransformCheckPoint();
        //player.MoveTowards(target);
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {
        CHeckPointPhase phase = CheckPointManager.Instance.GetCheckPointPhase();

        //if (!playerDied)
        //{
            switch (phase)
            {
                case CHeckPointPhase.Moving:
                    if (!targetAssigned)
                    {
                        Transform target = CheckPointManager.Instance.GetTransformCheckPoint();
                        player.MoveTowards(target);
                        targetAssigned = true;
                    }

                    break;
                case CHeckPointPhase.GetInPosition:

                    if (hasArrived == true)
                    {
                        checkPointAssigned = false;
                        CheckPointManager.Instance.phase = CHeckPointPhase.Spawning;
                    }

                    break;
                case CHeckPointPhase.Action:

                    player.action = true;

                    break;
                case CHeckPointPhase.WaitingBreforeLeaving:

                    targetAssigned = false;
                    hasArrived = false;

                    if (Time.time >= timeToLeaveCheckPoint && !checkPointAssigned)
                    {
                        CheckPointManager.Instance.GoToNextCheckPoint();
                        CheckPointManager.Instance.phase = CHeckPointPhase.Moving;
                        checkPointAssigned = true;
                    }
                    break;
                default:
                    break;
            }
        //}
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

    public void PlayerTransitionToNextCheckPoint()
    {
        hasArrived = false;
        player.action = false;
    }
}
