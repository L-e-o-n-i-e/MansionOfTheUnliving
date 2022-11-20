using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    List<IFlow> listManagers = new List<IFlow>();
    public Connector connector;

    private void Awake()
    {
        connector.Connect();

        //populer la liste des managers qui implementent 
        listManagers.Add(PlayerManager.Instance);
        //listManagers.Add(BulletManager.Instance);
        //listManagers.Add(EnemyManager.Instance);
        //listManagers.Add(LevelManager.Instance);
        //listManagers.Add(UIManager.Instance);


        foreach (var manager in listManagers)
        {
            manager.PreInitialize();
        }
    }

    private void Start()
    {
        //for loop qui appelle initialize sur tous les managers
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
