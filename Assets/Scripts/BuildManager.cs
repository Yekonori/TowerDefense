using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBlueprint _turretToBuild = null;

    public bool CanBuild { get { return _turretToBuild != null; } }

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene !");
            return;
        }

        instance = this;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that !");
            return;
        }

        PlayerStats.Money -= _turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Build : " + _turretToBuild.prefab.gameObject.name);
        Debug.Log("Money Left : " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        _turretToBuild = turretBlueprint;
    }
}
