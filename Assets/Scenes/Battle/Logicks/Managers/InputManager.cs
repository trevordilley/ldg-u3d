using System;
using UniRx;
using UnityEngine;

namespace Scenes.Battle.Logicks.Services
{
    public class InputManager : IUpdateable 
    {
        
       private readonly BehaviorSubject<bool> _rightMouseDown = new BehaviorSubject<bool>(false);

       public IObservable<bool> RightMouseDownObs => _rightMouseDown.AsObservable();


       private static InputManager _inputManager;
       public static InputManager Instance()
       {
           if (_inputManager != null) return _inputManager;
           _inputManager = new InputManager();
           Debug.Log("Creating new instance of InputService!");

           return _inputManager;
       }
       private InputManager() {}
       
       public void Update(float dt)
       {
           if (Input.GetMouseButtonDown(1))
           {
               _rightMouseDown.OnNext(true);
           }

           if (Input.GetMouseButtonUp(1))
           {
               _rightMouseDown.OnNext(false);
           }
           
       }
    }
}