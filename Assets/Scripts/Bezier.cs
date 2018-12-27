using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

[RequireComponent(typeof(LineRenderer))]

public class Bezier : MonoBehaviour
{
    [Header("Parent Points")]
    public Transform controlPoints;
    private LineRenderer lineRenderer;
    private List<Transform> _listPoints;
    private Vector3[] _pointsPosition;

    private int _curveCount = 0;
    private int _layerOrden = 0;
    private int _count = 0;

    [Header("Numero de puntos")]
    [Range(10, 50)]
    public int segment_count = 20;

    public bool isClose;

    public enum MoveType
    {
        LOOP = 0,
        PING_PONG = 1,
        ONE_WAY 
    }

    [Header("Target Follow")]
    [SerializeField]
    private MoveType mType;

    private int _childIndex = -1;
    private int _direction = 1;

    public delegate void Callback();
    public Callback callback = null;

    [Header("Target Parameter")]
    private Vector3 _targetPosition;

    [SerializeField]
    [Range(10.0f, 50.0f)]
    private float speed = 10.0f;

    public Transform Target;

    private void Awake()
    {

        if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        lineRenderer.sortingLayerID = _layerOrden;
    }

    void Start()
    {
        _listPoints = new List<Transform>();

        for (int i = 0; i < controlPoints.childCount; i++)
        {
            _listPoints.Add(controlPoints.GetChild(i));
        }

        _curveCount = (int)_listPoints.Count / 3;

        _count = segment_count * _curveCount;

        _pointsPosition = new Vector3[_count];

        lineRenderer.positionCount = _count;

        StartFollow();
    }

    void Update()
    {
        DrawCurve();

        TargetFollowPoint();
    }

    void DrawCurve()
    {
        for (int j = 0; j < _curveCount; j++)
        {
            for (int i = 0; i < segment_count; i++)
            {
                float t = i / (float)(segment_count);

                int index = j * 3;

                int nodeIndex = (j * segment_count) + i;

                _pointsPosition[nodeIndex] = CalculateCubicBezierPoint(t, _listPoints[index + 0].position, _listPoints[index + 1].position, _listPoints[index + 2].position, _listPoints[index + 3].position);
            }

            lineRenderer.SetPositions(_pointsPosition);
        }

        if (isClose)
        {
            if(_pointsPosition.Length % 2 == 0)
            {
                _listPoints[controlPoints.childCount - 1] = controlPoints.GetChild(0);
                lineRenderer.loop = true;
            }
        }
        else if (!isClose)
        {
            _listPoints[controlPoints.childCount - 1] = controlPoints.GetChild(controlPoints.childCount - 1);
            lineRenderer.loop = false;
        }
    }

    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

    private void OnEnd()
    {
        print("End");
    }

    void StartFollow()
    {
        Target.position = GetNextPointPosition();
        _targetPosition = GetNextPointPosition();
        callback += OnEnd;
    }

    void TargetFollowPoint()
    {
        Target.position = Vector3.MoveTowards(Target.position, _targetPosition, speed * Time.deltaTime);

        if (Target.position == _targetPosition)
        {
            _targetPosition = GetNextPointPosition();
        }
    }

    public Vector3 GetNextPointPosition()
    {
        _childIndex += _direction;

        switch (mType)
        {
            case MoveType.LOOP:
                if (_childIndex >= _pointsPosition.Length)
                {
                    _childIndex = 0;
                }
                break;
            case MoveType.PING_PONG:
                if (_childIndex >= _pointsPosition.Length)
                {
                    _childIndex -= 2;
                    _direction *= -1;
                }
                else if (_childIndex < 0)
                {
                    _childIndex = 1;
                    _direction *= -1;
                }
                break;
            case MoveType.ONE_WAY:
                if (_childIndex >= _pointsPosition.Length)
                {
                    _childIndex -= _direction;

                    if (callback != null)
                    {
                        callback();
                    }
                }
                break;
        }

        return getChildPosByIndex(_childIndex);
    }
    public Vector3 getChildPosByIndex(int i)
    {
        return _pointsPosition[i];
    }

    public int getCurrentIndex()
    {
        return _childIndex;
    }

}
