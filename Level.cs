using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<string> seriesNames;
    private List<Series> seriesList = new List<Series>();
    private int currentSeries = 0;

    protected virtual void Start()
    {
        foreach (string name in seriesNames)
        {
            Series series = SeriesManager.Instance.GetSeriesByName(name);
            if (series != null)
            {
                seriesList.Add(series);
            }
        }

        ShuffleSeries();
        StartCoroutine(SpawnSeriesInOrder());
    }

    private void ShuffleSeries()
    {
        for (int i = 0; i < seriesList.Count; i++)
        {
            Series temp = seriesList[i];
            int randomIndex = Random.Range(i, seriesList.Count);
            seriesList[i] = seriesList[randomIndex];
            seriesList[randomIndex] = temp;
        }
    }

    private IEnumerator SpawnSeriesInOrder()
    {
        foreach (Series series in seriesList)
        {
            foreach (SeriesObject seriesObject in series.seriesObjects)
            {
                Instantiate(seriesObject.gameObject, SeriesManager.Instance.positionMap[seriesObject.position], Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
        }
        // Level complete
        LevelManager.Instance.LevelComplete();
    }
}