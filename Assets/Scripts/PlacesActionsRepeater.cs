using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlacesActionsRepeater : MonoBehaviour
{
    public PlacesManager PlacesManager
    {
        get
        {
            if (!_placesManager)
            {
                Awake();
            }
            
            return _placesManager;
        }
    }

    private PlacesManager _placesManager;
    
    void Awake()
    {
        _placesManager = FindObjectOfType<PlacesManager>();
    }

    public void OpenPlacesPicker()
    {
        Toggle(true);
    }

    private void Toggle(bool val)
    {
        if (!PlacesManager) return;
        
        PlacesManager.ToggleMap(val);
    }
}
