using System;
using Scenes.Battle.Logicks.Behaviours;
using UniRx;
using UnityEngine;

namespace Scenes.Battle.Logicks.Managers
{
    public class SelectionManager
    {
        private static SelectionManager _instance;

        public static SelectionManager Instance()
        {
            if (_instance != null) return _instance;
            _instance = new SelectionManager();
            Debug.Log("Creating new SelectionManager instance!!!");
            return _instance;
        }
        private SelectionManager () {}
        private readonly Subject<SelectionBehaviour[]> _selection = new Subject<SelectionBehaviour[]>();
        public  IObservable<SelectionBehaviour[]> SelectionObs => _selection.AsObservable().Share();

        public  void Select(SelectionBehaviour[] s)
        {
            _selection.OnNext(s);
        }

        public void Select(SelectionBehaviour s)
        {
            _selection.OnNext(new[]{s});
        }
    }
}

