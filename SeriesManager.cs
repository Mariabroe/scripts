using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Position
{
    RedSideUp,
    RedSideMid,
    RedSideDown,
    BlueSideUp,
    BlueSideMid,
    BlueSideDown,
    Double
}

[System.Serializable]
public class SeriesObject
{
    public GameObject gameObject;
    public Position position;
}

[System.Serializable]
public class Series
{
    public string name;
    public List<SeriesObject> seriesObjects;

    public Series()
    {
        seriesObjects = new List<SeriesObject>();
    }
}

public class SeriesManager : MonoBehaviour
{
    public static SeriesManager Instance { get; private set; }

    public List<Series> seriesList = new List<Series>();

    public Dictionary<Position, Vector3> positionMap = new Dictionary<Position, Vector3>
    {
        { Position.RedSideUp, new Vector3(0.65f, 2.5f, 20f) },
        { Position.RedSideMid, new Vector3(0.65f, 2.0f, 20f) },
        { Position.RedSideDown, new Vector3(0.65f, 1.5f, 20f) },
        { Position.BlueSideUp, new Vector3(-0.65f, 2.5f, 20f) },
        { Position.BlueSideMid, new Vector3(-0.65f, 2.0f, 20f) },
        { Position.BlueSideDown, new Vector3(-0.65f, 1.5f, 20f) },
        { Position.Double, new Vector3(0.0f, 0.0f, 20f) }
    };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Series GetSeriesByName(string name)
    {
        foreach (Series series in seriesList)
        {
            if (series.name == name)
            {
                return series;
            }
        }
        return null;
    }
}
