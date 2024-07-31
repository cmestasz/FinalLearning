using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWarp : WarpController
{
    public enum WarpType { Up, Down, FromOutside, FromInside };
    [SerializeField] private int course;
    [SerializeField] private int floor;
    private int floorDest;
    private int courseDest;
    private WarpType cameFrom;
    [SerializeField] private WarpType warpType;
    void Start()
    {
        sceneName = "Tower";
        courseDest = TowerData.course;
    }

    public override void SetParams()
    {
        TowerData.course = courseDest;
        TowerData.floor = floorDest;
        TowerData.cameFrom = cameFrom;
    }

    public override bool ValidateWarp()
    {
        switch (warpType)
        {
            case WarpType.Up:
                if (TowerData.floor >= TowerData.MAX_FLOOR)
                {
                    Debug.Log("No way up");
                    return false;
                }
                floorDest = TowerData.floor + 1;
                break;
            case WarpType.Down:
                if (TowerData.floor <= 0)
                {
                    Debug.Log("No way down");
                    return false;
                }
                floorDest = TowerData.floor - 1;
                break;
            case WarpType.FromOutside:
                floorDest = floor;
                courseDest = course;
                break;
            case WarpType.FromInside:
                floorDest = TowerData.floor;
                courseDest = TowerData.course;
                break;
        }
        cameFrom = warpType;
        return true;
    }
}
