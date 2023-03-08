using System.Collections.Generic;
using UnityEngine;
using TimerSystem;

namespace Core
{
    [CreateAssetMenu(fileName = "TimeController", menuName = "Controllers/TimeController")]
    public class TimeController : Controller, IWaitTimer
    {
        private List<IWaitTimer> waitingObjects = new List<IWaitTimer>();

        public void AddWaitingObject(IWaitTimer waitingObject)
        {
            waitingObjects.Add(waitingObject);
        }

        public void RemoveWaitingObject(IWaitTimer waitingObject)
        {
            if (waitingObjects.Contains(waitingObject))
            {
                waitingObjects.Remove(waitingObject);
            }
        }

        public void TickTimer()
        {
            if (waitingObjects.Count > 0)
            {
                for (int i = 0; i < waitingObjects.Count; i++)
                {
                    waitingObjects[i].TickTimer();
                }
            }
        }
    }
}