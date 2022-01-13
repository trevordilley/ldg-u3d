using System;
using Scenes.Battle.Logicks.Managers;
using Scenes.Battle.Logicks.Services;
using UniRx;
using UnityEngine;

namespace Scenes.Battle.Logicks.Behaviours
{
    public class MovementBehaviour : MonoBehaviour
    {
        public float speed;
        private void Start()
        {
            Observable.EveryUpdate()
                .CombineLatest(
                    DestinationManager.Instance().CurrentDestination.Where(d => d.HasValue),
                    (dt, d) => Vector2.MoveTowards(transform.position, d.Value, dt * speed))
                .Subscribe(d => this.transform.position = d)
                .AddTo(this);
        }
    }
}