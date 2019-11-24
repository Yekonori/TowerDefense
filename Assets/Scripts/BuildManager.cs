using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private GameObject _turretToBuild = null;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene !");
            return;
        }

        instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
}
