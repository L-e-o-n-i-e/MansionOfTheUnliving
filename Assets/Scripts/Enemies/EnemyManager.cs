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
    public bool playerHasArrived = false;
    public GameObject zombiePrefab;
    public GameObject breakDancerPrefab;
    public float colliderBuffer = .7f;
    private bool enemiesSpawned = false;

    public void PreInitialize()
    {
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {
        if (playerHasArrived == true && !enemiesSpawned)
        {
            SpawnEnemies();
        }
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

    public void SpawnEnemies()
    {
        int nbZombies, nbBreakDancers;
        Transform spawnArea;
        CheckPointManager.Instance.GetNbEnemiesToSpawn(out nbZombies, out nbBreakDancers, out spawnArea);

        
        for (int i = 0; i < nbZombies; i++)
        {
            GameObject zombie = GameObject.Instantiate<GameObject>(zombiePrefab);
            Vector3 spawnPos = GetSpawnPosition(spawnArea);
            zombie.transform.position = spawnPos;
            zombie.GetComponent<Agent>().followTarget = PlayerManager.Instance.GetPlayerTransform();
        }

        for (int i = 0; i < nbBreakDancers; i++)
        {
            GameObject breakDancer = GameObject.Instantiate<GameObject>(breakDancerPrefab);
            Vector3 spawnPos = GetSpawnPosition(spawnArea);
            breakDancer.transform.position = spawnPos;
            breakDancer.GetComponent<Agent>().followTarget = PlayerManager.Instance.GetPlayerTransform();
        }

        enemiesSpawned = true;
    }

    public Vector3 GetSpawnPosition(Transform spawnArea)
    {

        float x_min = spawnArea.position.x - spawnArea.transform.localScale.x / 2 + colliderBuffer;
        float x_max = spawnArea.position.x + spawnArea.transform.localScale.x / 2 - colliderBuffer;
        float z_min = spawnArea.position.z - spawnArea.transform.localScale.z / 2 + colliderBuffer;
        float z_max = spawnArea.position.z + spawnArea.transform.localScale.z / 2 - colliderBuffer;

       float x =  Random.Range(x_min, x_max);
       float z =  Random.Range(z_min, z_max);

        return new Vector3(x, 1, z);

        
    }

}
