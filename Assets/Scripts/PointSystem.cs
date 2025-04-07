using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PointSystem : MonoBehaviour
{
    [SerializeField]
    private float _startingPoints = 0.0f;

    [SerializeField]
    private TextMeshProUGUI _pointText;

    private float _points;
    private float _pointMult;

    public float CurrentScore { get { return _points; } }


    private void Start()
    {
        _points = _startingPoints;
        _pointMult = 1.0f;

        if (_pointText)
        {
            _pointText.text = _points.ToString("00.00");
        }
        //Debug.Log("Start " + _points + " | " + _pointMult);
    }
    public void IncreasePoints()
    {
        _points += 1;
        //Debug.Log("Increase " + _points + " | " + _pointMult);
    }

    private void Update()
    {
        //_points = _points + (1 * _pointMult);

        if (_pointText)
        {
            //Debug.Log("Update " + _points + " | " + _pointMult);
            _pointText.text = _points.ToString("00.00");
        }
    }
}
