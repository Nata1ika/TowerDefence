using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    [SerializeField] AnimationCurve _curveX;
    [SerializeField] AnimationCurve _curveY;

    float _maxTime = 0;

    private void Start()
    {
        float maxTimeX = 0;
        foreach (var key in _curveX.keys)
        {
            if (key.time > _maxTime)
            {
                maxTimeX = key.time;
            }
        }

        float maxTimeY = 0;
        foreach (var key in _curveY.keys)
        {
            if (key.time > _maxTime)
            {
                maxTimeY = key.time;
            }
        }

        _maxTime = Mathf.Min(maxTimeX, maxTimeY);

        if (!Mathf.Approximately(maxTimeX, maxTimeY))
        {
            Debug.LogError(string.Format("maxTime X, Y not Approximately: {0}, {1}", maxTimeX, maxTimeY));
        }
    }

    public Vector2? GetPosition(float time)
    {
        if (time > _maxTime)
        {
            return null;
        }
        else
        {
            return new Vector2(_curveX.Evaluate(time), _curveY.Evaluate(time));
        }
    }
}
