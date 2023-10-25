using System;
using UnityEngine;

namespace _.Scripts.UI
{
    public class ContextPresenter : MonoBehaviour
    {
        private ContextView _view;
        private ContextModel _model;

        private void Start()
        {
            _view ??= GetComponent<ContextView>();
            _model ??= GetComponent<ContextModel>();
        }
    }
}