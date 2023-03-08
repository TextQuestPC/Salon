using System;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "StateDataController", menuName = "Controllers/StateDataController")]
    public class StateDataController : Controller
    {
        #region ACTIONS

        public event Action PausedApplication;
        public event Action UnpausedApplication;
        public event Action FocusedApplication;
        public event Action UnfocusedApplication;

        #endregion ACTIONS

        #region STATES_GAME

        public event Action<bool> ChangeCanMove;
        public event Action<bool> ChangeCanSpawn;
        public event Action<bool> ChangeTimeGo;

        private bool CanMove
        {
            set => ChangeCanMove?.Invoke(value);
        }

        private bool CanSpawn
        {
            set => ChangeCanSpawn?.Invoke(value);
        }

        private bool TimeGo
        {
            set => ChangeTimeGo?.Invoke(value);
        }

        #endregion STATES_GAME

        public override void OnStart()
        {
            CanMove = true;
            CanSpawn = true;
            TimeGo = true;
        }
    }
}