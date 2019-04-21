using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject MaleHero;
    public GameObject FemaleHero;

    private void Start()
    {
        User.OnUserChanged += (u) => Spawn();
        Spawn();
    }

    void Spawn()
    {
        transform.RemoveAllChildren();

        if (User.Current != null)
        {
            var spawned = Instantiate(User.Current.Sex ? MaleHero : FemaleHero, transform);
            spawned.transform.localPosition = Vector3.zero;
        }
    }
}
