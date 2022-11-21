using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager 
{
    #region Singleton
    //SINGLETON! REMOVE MONOBEHAVIOR
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }

    }
    private UIManager() { }
    #endregion

    public RectTransform hpPanel;
    public RectTransform ammoPanel;
    public Image hpImgPrefab;
    public Image ammoImgPrefab;

    public int MAX_AMMO = 10;
        
    public void StartGame()
    {
        for (int i = 0; i < PlayerManager.Instance.START_AMMO; i++)
        {
            Image goToClone = GameObject.Instantiate<Image>(ammoImgPrefab);
            goToClone.transform.SetParent(ammoPanel);
        }

        for (int i = 0; i < PlayerManager.Instance.START_HP; i++)
        {
            Image goToClone = GameObject.Instantiate<Image>(hpImgPrefab);
            goToClone.transform.SetParent(hpPanel);
        }
    }

    public void AddAmmo()
    {
        Image goToClone = GameObject.Instantiate<Image>(ammoImgPrefab);
        goToClone.transform.SetParent(ammoPanel);
    }

    public void LoseAmmo()
    {
        ammoPanel.GetChild(ammoPanel.childCount - 1).GetComponent<Image>().enabled = false;
    }

    public void AddHp()
    {
        Image goToClone = GameObject.Instantiate<Image>(hpImgPrefab);
        goToClone.transform.SetParent(hpPanel);
    }

    public void LoseHp()
    {
        ammoPanel.GetChild(hpPanel.childCount - 1).GetComponent<Image>().enabled = false;
    }
}
