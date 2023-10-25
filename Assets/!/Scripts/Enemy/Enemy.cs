using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
public class Enemy : MonoBehaviour, IMarkable
{
    public bool HasMarked { get; set; }

    public bool CanPull { get; set; }
    public bool CanDash { get; set; }
    public Vector3 PullDirection { get; set; }

    private Rigidbody _rb;
    [SerializeField] private GameObject visualizePullDirection;
    private BehaviorTree BT;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        BT = GameObject.FindObjectOfType<BehaviorTree>();
    }

    private void Start()
    {
        visualizePullDirection.SetActive(false);
        PullDirection = Vector3.zero;
        CanPull = true;
    }

    private void Update()
    {
        if (PullDirection != Vector3.zero)
        {
            SetVisualizePullDirection(PullDirection);
        }
        else visualizePullDirection.SetActive(false);
    }

    public void SetMark(bool isMark)
    {
        if (isMark)
        {
            HasMarked = true;
            GetComponent<MeshRenderer>().material.color = Color.red;
            StartCoroutine(nameof(CountingMarkTime));
            return;
        }

        HasMarked = false;
        GetComponentInChildren<MeshRenderer>().material.color = Color.white;
    }

    public void Pull()
    {
        BT.SendEvent("HasStun");
        Vector3 dir = PullDirection - transform.position;
        _rb.AddForce(dir.normalized * 10, ForceMode.Impulse);
    }

    public void SetVisualizePullDirection(Vector3 direction)
    {
        visualizePullDirection.SetActive(true);
        Vector3 look = new Vector3(PullDirection.x, 
            visualizePullDirection.transform.position.y, PullDirection.z);
        visualizePullDirection.transform.LookAt(look);
    }

    IEnumerator CountingMarkTime()
    {
        yield return new WaitForSeconds(4);
        SetMark(false);

        yield return null;
    }

  
}