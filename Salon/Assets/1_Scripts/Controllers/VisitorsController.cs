using System.Collections.Generic;
using Characters;
using ObjectsOnScene;
using UnityEngine;
using VisitorSystem;

namespace Core
{
    [CreateAssetMenu(fileName = "VisitorsController", menuName = "Controllers/VisitorsController")]
    public class VisitorsController : Controller
    {
        private List<Visitor> visitors = new List<Visitor>();

        private ServicesController serviceManager;

        private Visitor currentVisitor;

        public override void OnStart()
        {
            serviceManager = BoxControllers.GetController<ServicesController>();

            CreateVisitor();
        }

        public void ChooseNextActionVisitor(Visitor visitor)
        {
            ChooseActionForVisitor(visitor);
        }

        private void CreateVisitor()
        {
            Visitor visitor = BoxControllers.GetController<CreatorController>().CreateVisitor();
            DataVisit[] data = BoxControllers.GetController<BalanceController>().GetDataVisit();
            visitor.SetDataVisit = data;
            visitors.Add(visitor);

            ChooseActionForVisitor(visitor);
        }

        private void ChooseActionForVisitor(Visitor visitor)
        {
            currentVisitor = visitor;
            StateVisitor state = visitor.StateVisitor;

            if (state == StateVisitor.StartInDoor)
            {
                VisitorCameInSalon();
            }
            if (state == StateVisitor.WaitProcedure)
            {
                ChooseService();
            }
            else if (state == StateVisitor.StandByService)
            {
                visitor.SitDownOnChair();
            }
            else if (state == StateVisitor.CompleteAllProcedure)
            {
                VisitorEndAllProcedure();
            }
            else if (state == StateVisitor.GoToCash)
            {
                currentVisitor.StateVisitor = StateVisitor.StandByCash;

                CashZone cashZone = serviceManager.GetCashZone;
                currentVisitor.GoToTargetTransform(cashZone.GetVisitorPosition.transform);
            }
            else if (state == StateVisitor.StandByCash)
            {
                visitor.LookAt(serviceManager.GetCashZone.GetLookPosition.transform);
                visitor.StandAroundCash();

                serviceManager.GetCashZone.SetWaitVisitor = visitor;
            }
            else if (state == StateVisitor.GetMoney)
            {
                currentVisitor.GoToTargetTransform(PositionsOnScene.Instance.GetSpawnVisitorPos.transform);
            }
        }

        private void VisitorCameInSalon()
        {
            if (serviceManager.CheckFreeService(currentVisitor.GetCurrentTypeService))
            {
                float zValueService = serviceManager.GetFreeService(currentVisitor.GetCurrentTypeService).transform.position.z;
                GameObject startMovePos;

                if (zValueService > currentVisitor.transform.position.z)
                {
                    startMovePos = PositionsOnScene.Instance.GetLeftStartMovePos;
                }
                else
                {
                    startMovePos = PositionsOnScene.Instance.GetRightStartMovePos;
                }

                currentVisitor.StateVisitor = StateVisitor.WaitProcedure;
                currentVisitor.GoToTargetTransform(startMovePos.transform);
            }
            else // If service is not free
            {
                RestZone restZone = serviceManager.GetRestZone;

                currentVisitor.StateVisitor = StateVisitor.StandByRestZone;
                currentVisitor.GoToTargetTransform(restZone.transform);
            }
        }

        private void VisitorEndAllProcedure()
        {
            GameObject startMovePos;

            if (currentVisitor.transform.position.z > 0)
            {
                startMovePos = PositionsOnScene.Instance.GetLeftStartMovePos;
            }
            else
            {
                startMovePos = PositionsOnScene.Instance.GetRightStartMovePos;
            }

            currentVisitor.StateVisitor = StateVisitor.GoToCash;
            currentVisitor.GoToTargetTransform(startMovePos.transform);
        }

        private void ChooseService()
        {
            Service service = serviceManager.GetFreeService(currentVisitor.GetCurrentTypeService);

            if (service != null)
            {
                currentVisitor.StateVisitor = StateVisitor.StandByService;

                currentVisitor.GoToTargetService(service);
                return;
            }
        }
    }
}