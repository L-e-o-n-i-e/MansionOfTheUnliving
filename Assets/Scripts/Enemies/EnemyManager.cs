using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Zombie, BreakDancer }

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


    public bool playerHasArrived = false;
    public GameObject zombiePrefab;
    public GameObject breakDancerPrefab;
    public float colliderBuffer = .7f;
    private bool enemiesSpawned = false;
    public List<BreakDancer> breakDancers = new List<BreakDancer>();
    public List<Zombie> zombies = new List<Zombie>();

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

        //if(zombies.Count == 0 && breakDancers.Count == 0)
        //{
        //    CheckPointManager.Instance.GoToNextCheckPoint();
        //}
    }

    public void PhysicsRefresh()
    {
    }

    public void EndGame()
    {
    }

    public void SpawnEnemies()
    {
        int nbZombies, nbBreakDancers;
        Transform spawnArea, target;
        CheckPointManager.Instance.GetNbEnemiesToSpawn(out nbZombies, out nbBreakDancers, out spawnArea);
        target = PlayerManager.Instance.GetPlayerTransform();

        for (int i = 0; i < nbZombies; i++)
        {
            GameObject zombie = GameObject.Instantiate<GameObject>(zombiePrefab);
            Vector3 spawnPos = GetSpawnPosition(spawnArea);
            zombie.transform.position = spawnPos;
            zombie.GetComponent<Agent>().followTarget = target;

            AddZombieToList(zombie.GetComponent<Zombie>());
        }

        for (int i = 0; i < nbBreakDancers; i++)
        {
            GameObject breakDancer = GameObject.Instantiate<GameObject>(breakDancerPrefab);
            Vector3 spawnPos = GetSpawnPosition(spawnArea);
            breakDancer.transform.position = spawnPos;
            breakDancer.GetComponent<Agent>().followTarget = target;

            AddBreakDancerToList(breakDancer.GetComponent<BreakDancer>());
        }

        enemiesSpawned = true;
    }

    public Vector3 GetSpawnPosition(Transform spawnArea)
    {

        float x_min = spawnArea.position.x - spawnArea.transform.localScale.x / 2 + colliderBuffer;
        float x_max = spawnArea.position.x + spawnArea.transform.localScale.x / 2 - colliderBuffer;
        float z_min = spawnArea.position.z - spawnArea.transform.localScale.z / 2 + colliderBuffer;
        float z_max = spawnArea.position.z + spawnArea.transform.localScale.z / 2 - colliderBuffer;

        float x = Random.Range(x_min, x_max);
        float z = Random.Range(z_min, z_max);

        return new Vector3(x, 1, z);
    }

    public void GotHit(System.Type type, Transform enemy, string tag)
    {
        bool deadEnemy = false;

        //If Enemy is a Zombie
        if (type.ToString() == "Zombie"){
            Zombie zombie = enemy.GetComponent<Zombie>();
            deadEnemy = zombie.GetDmg(tag);

            if (deadEnemy)
            {
                RemoveZombieFromList(zombie);
            }
        }
        //If enemy is a BreakDancer
        else if(type.ToString() == "BreakDancer"){
            BreakDancer bd = enemy.GetComponent<BreakDancer>();
            deadEnemy = bd.GetDmg(tag);

            if (deadEnemy)
            {
                RemoveBreakDancerFromList(bd);
            }
        }   
    }

    public void HitPlayer()
    {

    }

    public void RemoveZombieFromList(Zombie zombie)
    {
        if (zombies.Count != 0)
            zombies.Remove(zombie);
    }

    public void RemoveBreakDancerFromList(BreakDancer breakDancer)
    {
        if (breakDancers.Count != 0)
            breakDancers.Remove(breakDancer);

    }

    public void AddZombieToList(Zombie zombie)
    {
        zombies.Add(zombie);
    }

    public void AddBreakDancerToList(BreakDancer breakDancer)
    {
        breakDancers.Add(breakDancer);
    }
}