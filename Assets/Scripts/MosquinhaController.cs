using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquinhaController : MonoBehaviour
{
    public float _moveSpeedMosquinha = 3.5f;
    private Vector2 _mosquinhaDirection;
    private Rigidbody2D _mosquinhaRB2D;

    public DetectionController _detectionArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mosquinhaRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _mosquinhaDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if(_detectionArea.detectedObjs.Count > 0)
        {
            _mosquinhaDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            _mosquinhaRB2D.MovePosition(_mosquinhaRB2D.position + _mosquinhaDirection * _moveSpeedMosquinha * Time.fixedDeltaTime);
        }
    }
}
