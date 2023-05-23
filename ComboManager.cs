using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public int combo = 0;
    
    private void Start()
    {
        ResetCombo();
    }

    public void IncrementCombo()
    {
        combo++;
    }

    public void ResetCombo()
    {
        combo = 0;
    }
}
