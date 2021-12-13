using System;
using UniRx;
using UnityEngine;

namespace Scenes.Battle.Logicks.Services
{
    public class InputManager : IUpdateable 
    {
        
       private readonly BehaviorSubject<Vector2?> _rightMouseDown = new BehaviorSubject<Vector2?>(null);

       public IObservable<Vector2?> RightMouseDownObs => _rightMouseDown.AsObservable();


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
               _rightMouseDown.OnNext(Input.mousePosition);
           }
           else
           {
               _rightMouseDown.OnNext(null);
           }

           if (Input.GetMouseButtonUp(1))
           {
               _rightMouseDown.OnNext(Input.mousePosition);
           }
           else
           {
               _rightMouseDown.OnNext(null);
           }
           
       }
    }
}