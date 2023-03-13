using System;
using System.Linq;
using Logs;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "EventsController", menuName = "Controllers/Game/EventsController")]
    public class EventsController : Controller
    {
        private Action changeLocalization;

        private Action<bool> changeTimeGoEvent;
        private Action<bool> changeCanMoveEvent;
        private Action<int> changeGoldEvent;


        public void SubscribeOnChangeLocalization(Action sender)
        {
            if (changeLocalization != null && changeLocalization.GetInvocationList().Contains(sender))
            {
                LogManager.LogError($"Try 2 subscribes on ChangeGoldEvent");
            }
            else
            {
                changeLocalization += sender;
            }
        }

        public void UnsubscribeOnChangeLocalization(Action sender)
        {
            changeLocalization -= sender;
        }

        public void ChangeLocalization()
        {
            changeLocalization?.Invoke();
        }

        public void SubscribeOnTimeGo(Action<bool> sender)
        {
            if (changeTimeGoEvent != null && changeTimeGoEvent.GetInvocationList().Contains(sender))
            {
                LogManager.LogError($"Try 2 subscribes on ChangeGoldEvent");
            }
            else
            {
                changeTimeGoEvent += sender;
            }
        }

        public void UnsubscribeOnTimeGo(Action<bool> sender)
        {
            changeTimeGoEvent -= sender;
        }

        public void ChangeTimeGo(bool value)
        {
            changeTimeGoEvent?.Invoke(value);
        }


        public void SubscribeOnCanMove(Action<bool> sender)
        {
            if (changeCanMoveEvent != null && changeCanMoveEvent.GetInvocationList().Contains(sender))
            {
                LogManager.LogError($"Try 2 subscribes on ChangeGoldEvent");
            }
            else
            {
                changeCanMoveEvent += sender;
            }
        }

        public void UnsubscribeOnCanMove(Action<bool> sender)
        {
            changeCanMoveEvent -= sender;
        }

        public void ChangeCanMove(bool value)
        {
            changeCanMoveEvent?.Invoke(value);
        }


        public void SubscribeOnChangeGold(Action<int> sender)
        {
            if (changeGoldEvent!= null && changeGoldEvent.GetInvocationList().Contains(sender))
            {
                LogManager.LogError($"Try 2 subscribes on ChangeGoldEvent");
            }
            else
            {
                changeGoldEvent += sender;
            }
        }

        public void UnsubscribeOnChangeGold(Action<int> sender)
        {
            changeGoldEvent -= sender;
        }

        public void ChangeGold(int value)
        {
            changeGoldEvent?.Invoke(value);
        }
    }
}