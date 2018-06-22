using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] Tower[] _tower;
    [SerializeField] Camera _camera;

    Tower spawn;

    public void StartSpawn(int index)
    {
        if (spawn == null && index >= 0 && index < _tower.Length && MoneyController.Money > _tower[index].price)
        {
            spawn = Instantiate(_tower[index], transform);
            StartCoroutine(SpawnCoroutine());
        }
    }

    IEnumerator SpawnCoroutine()
    {
        yield return null;

        while (spawn != null)
        {
            Vector3? pos = MousePosition();
            if (pos.HasValue)
            {
                spawn.gameObject.transform.position = new Vector3(pos.Value.x, transform.position.y, pos.Value.z);
            }

            if (Input.GetMouseButtonDown(0))
            {
                MoneyController.Reward(-spawn.price);
                spawn.isActive = true;
                spawn = null;
            }

            yield return null;
        }
        yield return null;
    }

    Vector3? MousePosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1))
        {
            return (hit.point);
        }
        else
        {
            return null;
        }
    }
}
