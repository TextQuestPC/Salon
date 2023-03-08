using Core;
using ObjectsOnScene;
using System;
using UnityEngine;

namespace SystemTarget
{
    public class TargetTowerSystem : TargetSystem
    {
        protected Action<ObjectScene> waitTarget;

        //public void SubscribeOnGetTarget(Action<ObjectScene> function)
        //{
        //    ChooseTarget();

        //    if (target != null)
        //    {
        //        function.Invoke(target);
        //    }
        //    else
        //    {
        //        waitTarget = function;
        //    }
        //}

        //private void ChooseTarget()
        //{
        //    target = BoxControllers.GetController<EnemiesManager>().GetFirstEnemy();

        //    if (target == null)
        //    {
        //        Debug.Log($"Нет цели для Tower. Enemy = null");

        //        BoxControllers.GetController<EnemiesManager>().NewEnemy += WaitTarget;
        //    }
        //}

        //private void WaitTarget(ObjectScene objectScene)
        //{
        //    BoxControllers.GetController<EnemiesManager>().NewEnemy -= WaitTarget;
        //    target = objectScene ;

        //    if (waitTarget != null)
        //    {
        //        waitTarget.Invoke(target);
        //        waitTarget = null;
        //    }
        //}
    }
}