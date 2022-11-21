using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    List<IFlow> listManagers = new List<IFlow>();
    public Connector connector;

    private void Awake()
    {
        connector.Connect();
        
        listManagers.Add(PlayerManager.Instance);
        listManagers.Add(EnemyManager.Instance);
        listManagers.Add(CheckPointManager.Instance);
        UIManager.Instance.StartGame();


        foreach (var manager in listManagers)
        {
            manager.PreInitialize();
        }
    }

    private void Start()
    {
        foreach (var manager in listManagers)
        {
            manager.Initialize();
        }
       

    }


    private void Update()
    {
        foreach (var manager in listManagers)
        {
            manager.Refresh();
        }
    }

    private void FixedUpdate()
    {

        foreach (var manager in listManagers)
        {
            manager.PhysicsRefresh();
        }
    }
}
