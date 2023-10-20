using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
   [SerializeField]
   private List<Obstacle> obstacles = new List<Obstacle>();

    public void SetObstaclesSpeed(float value)
    {
        for(int i = 0; i < obstacles.Count; i++)
        {
            obstacles[i].SetSpeed(value);
        }
    }

}
