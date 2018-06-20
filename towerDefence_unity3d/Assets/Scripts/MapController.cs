using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] MapInfo[] _maps;
    MapInfo _map;

    public int Count => _maps != null ? _maps.Length : 0;

    public void Show(int index)
    {
        if (index >= 0 && index < Count)
        {
            if (_map != null)
            {
                Destroy(_map.gameObject);
            }
            _map = Instantiate<MapInfo>(_maps[index], transform.position, transform.rotation, transform);
        }
        else
        {
            Debug.LogError("Not Corrent map index " + index);
        }
    }

    public Vector2? GetPosition(float time)
    {
        return _map == null ? null : _map.GetPosition(time);
    }
}
