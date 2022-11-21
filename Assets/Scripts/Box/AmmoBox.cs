using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int nbOfAmmo = 3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < nbOfAmmo; i++)
        {
            UIManager.Instance.AddAmmo();
        }
    }
}
