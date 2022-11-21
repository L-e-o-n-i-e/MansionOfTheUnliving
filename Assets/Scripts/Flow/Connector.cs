using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connector : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<CheckPoint> CheckPoints = new List<CheckPoint>();

    [Header("UI Elements")]
    public RectTransform hpPanel;
    public RectTransform lifePanel;
    public Image hpImgPrefab;
    public Image ammoImgPrefab;

    [Header("Sound Effects")]
    public AudioClip playerDyingClip;
    public AudioClip zombieGirlDyingClip;
    public AudioClip breakDancerDeathClip;
    public AudioClip zombieComingClip;

    [Header("Enemies")]
    public GameObject zombiePrefab;
    public GameObject breakDancerPrefab;

    public void Connect()
    {
        PlayerManager.Instance.playerPrefab = playerPrefab;
        CheckPointManager.Instance.list = CheckPoints;
        UIManager.Instance.hpPanel = hpPanel;
        UIManager.Instance.ammoPanel = lifePanel;
        UIManager.Instance.hpImgPrefab = hpImgPrefab;
        UIManager.Instance.ammoImgPrefab = ammoImgPrefab;
        EnemyManager.Instance.zombiePrefab = zombiePrefab;
        EnemyManager.Instance.breakDancerPrefab = breakDancerPrefab;

    }
}
