using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField]
    private List<Level> levels;
    private int currentLevel = 0;

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

    private void Start()
    {
        if (levels.Count > 0)
        {
            StartLevel(currentLevel);
        }
    }

    private void StartLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levels.Count)
        {
            Instantiate(levels[levelIndex], transform);
        }
    }

    public void LevelComplete()
    {
        // Wait for a short delay, then start the next level
        StartCoroutine(WaitAndStartNextLevel(2f));
    }

    private IEnumerator WaitAndStartNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);

        currentLevel++;
        if (currentLevel < levels.Count)
        {
            StartLevel(currentLevel);
        }
        else
        {
            Debug.Log("All levels complete!");
        }
    }
}
