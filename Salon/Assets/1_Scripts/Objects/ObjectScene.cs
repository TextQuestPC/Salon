using System;
using UnityEngine;

namespace ObjectsOnScene
{
    public abstract class ObjectScene : MonoBehaviour, IInitialize
    {
        public event Action<ObjectScene> DeathObjectEvent;

        public virtual void OnInitialize() { }

        public virtual void OnStart() { }

        protected virtual void Death() { }

        protected void DeathInvoke()
        {
            DeathObjectEvent?.Invoke(this);
        }
    }
}