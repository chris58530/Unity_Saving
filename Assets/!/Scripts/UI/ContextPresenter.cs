using System;
using _.Scripts.Tools;
using UniRx;
using UnityEngine;

namespace _.Scripts.UI
{
    public class ContextPresenter : Singleton<ContextPresenter>
    {
        // private ContextView _view;
        // private ContextModel _model;
        //
        // protected override void Awake()
        // {
        //     base.Awake();
        //     _view ??= GetComponentInChildren<ContextView>();
        //     _model ??= GetComponentInChildren<ContextModel>();
        // }
        // private void Start()
        // {
        //     _model.abilityValue.Skip(1)
        //         .Subscribe(_ =>
        //         {
        //             Debug.Log("index 改變");
        //         }).AddTo(this);
        // }
        // [ContextMenu("UseAbility")]
        // public void UseAbility()
        // {
        //     _model.abilityValue.Value -= 1;
        // }
        // [ContextMenu("GetHurt")]
        //
        // public void GetHurt(float damage)
        // {
        //     _model.hpValue.Value -= damage;
        // }
      
    }
}