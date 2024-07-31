using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWarp : WarpController
{
    private enum WarpType { Up, Down, Inside };
    [SerializeField] private string course;
    [SerializeField] private int floor;
    private int floorDest;
    [SerializeField] private WarpType warpType;
    void Start()
    {
        sceneName = "Tower";
    }

    public override void SetParams()
    {
        TowerData.course = course;
        TowerData.floor = floorDest;
        
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
                if (TowerData.floor <= 1)
                {
                    Debug.Log("No way down");
                    return false;
                }
                floorDest = TowerData.floor - 1;
                break;
            case WarpType.Inside:
                floorDest = floor;
                break;
        }
        return true;
    }
}
