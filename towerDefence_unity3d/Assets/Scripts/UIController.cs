using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] MapController _map;
    [SerializeField] GameObject _ui;

    private void Start()
    {
        GameController.StopGameEvent += ShowUI;
    }

    private void OnDestroy()
    {
        GameController.StopGameEvent -= ShowUI;
    }

    public void Click(int index)
    {
        _ui.SetActive(false);
        _map.Show(index);
        GameController.StartGame();
    }

    void ShowUI()
    {
        _ui.SetActive(true);
    }
}
