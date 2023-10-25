using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class Enemy : MonoBehaviour, IPullable
{
    [SerializeField] private GameObject visualizePullDirection;

    public Vector3 PullDirection { get; set; }

    private BehaviorTree _bt;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        // _bt = GameObject.FindObjectOfType<BehaviorTree>();
    }

    private void Start()
    {
        visualizePullDirection.SetActive(false);
        PullDirection = Vector3.zero;
    }

    private void Update()
    {
        if (PullDirection != Vector3.zero)
        {
            SetVisualizePullDirection(PullDirection);
        }
        else visualizePullDirection.SetActive(false);
    }

    // public void SetMark(bool isMark)
    // {
    //     if (isMark)
    //     {
    //         GetComponent<MeshRenderer>().material.color = Color.red;
    //         StartCoroutine(nameof(CountingMarkTime));
    //         return;
    //     }
    //
    //     GetComponentInChildren<MeshRenderer>().material.color = Color.white;
    // }
    public void Pull()
    {
        // _bt.SendEvent("HasStun");
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
    // IEnumerator CountingMarkTime()
    // {
    //     yield return new WaitForSeconds(4);
    //     SetMark(false);
    //
    //     yield return null;
    // }
}