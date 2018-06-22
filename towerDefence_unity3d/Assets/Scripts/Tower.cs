using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float _attack;
    public float price;
    [HideInInspector]
    public bool isActive = false;

    private void Start()
    {
        GameController.StopGameEvent += DestroyObj;
    }

    private void OnDestroy()
    {
        GameController.StopGameEvent -= DestroyObj;
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + other.gameObject.name + "   " + gameObject.name);

        if (isActive && other.gameObject.layer == LayerMask.NameToLayer("Mob"))
        {
            Mob mob = other.gameObject.GetComponent<Mob>();
            if (mob != null)
            {
                mob.Damage(_attack);
            }
        }
    }
}
