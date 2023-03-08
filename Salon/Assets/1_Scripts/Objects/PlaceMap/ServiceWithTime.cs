using Characters;
using Core;
using TimerSystem;
using UI;
using UnityEngine;

namespace ObjectsOnScene
{
    public class ServiceWithTime : Service, IWaitTimer
    {
        [SerializeField] private CanvasService canvasService;
        [SerializeField] private float timeProcedure = 2f;

        private float leftTimeProcedure;
        private bool procedureNow = false;

        #region PROCEDURE

        protected override void StartProcedure()
        {
            leftTimeProcedure = 0;
            canvasService.SetMaxValue = timeProcedure;
            canvasService.gameObject.SetActive(true);

            procedureNow = true;
            BoxControllers.GetController<TimeController>().AddWaitingObject(this);
        }

        public void TickTimer()
        {
            if (procedureNow)
            {
                leftTimeProcedure += Time.deltaTime;
                canvasService.ChangeValue(leftTimeProcedure);

                if (leftTimeProcedure >= timeProcedure)
                {
                    CompleteProcedure();
                }
            }
        }

        private void CompleteProcedure()
        {
            isFree = true;
            procedureNow = false;
            canvasService.gameObject.SetActive(false);

            BoxControllers.GetController<TimeController>().RemoveWaitingObject(this);
            BoxControllers.GetController<GameController>().CompleteProcedure(this);
            BoxControllers.GetController<GameController>().GetPlayer.EndProcedure();

            myVisitor.CompleteCurrentProcedure();
        }

        #endregion PROCEDURE
    }
}
