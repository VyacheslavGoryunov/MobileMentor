using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlacesManager : MonoBehaviour
    {
        public GameObject MapParent;
        public GameObject PlacesParent;
        public Place[] Places;

        private Dictionary<int, GameObject> _instancesCache = new Dictionary<int, GameObject>();

        private void Start()
        {
            if (Places.Length == 0)
            {
                Debug.LogError("No one places added");
            }
            
            BindAll();
            SwitchPlace(0);
        }

        protected void BindAll()
        {
            for (var i = 0; i < Places.Length; i++)
            {
                var place = Places[i];
                var index = i;
                place.TransitionButton.onClick.AddListener(() => SwitchPlace(index));
            }
        }
        
        public void SwitchPlace(int index)
        {
            foreach (var cachedPlace in _instancesCache.Values)
            {
                cachedPlace.SetActive(false);
            }

            if (!_instancesCache.ContainsKey(index))
            {
                _instancesCache[index] = Instantiate(Places[index].Prefab, PlacesParent.transform);
            }

            _instancesCache[index].SetActive(true);
            ToggleMap(false);
        }

        public void ToggleMap(bool val)
        {
            MapParent.SetActive(val);
            PlacesParent.SetActive(!val);
        }
    }
}