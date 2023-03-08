using ObjectsOnScene;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ServicesController", menuName = "Controllers/ServicesController")]
    public class ServicesController : Controller
    {
        private List<Service> services = new List<Service>();
        private RestZone restZone;
        private CashZone cashZone;

        public RestZone GetRestZone { get => restZone; }
        public CashZone GetCashZone { get => cashZone; }

        public override void OnInitialize()
        {
            services.Add(BoxControllers.GetController<CreatorController>().CreateService(TypeService.Haircut));
            services.Add(BoxControllers.GetController<CreatorController>().CreateService(TypeService.Nails));
            services.Add(BoxControllers.GetController<CreatorController>().CreateService(TypeService.Brows));
                        
            restZone = BoxControllers.GetController<CreatorController>().CreateRestZone();
            cashZone = BoxControllers.GetController<CreatorController>().CreateCashZone();
        }

        public bool CheckFreeService(TypeService typeService)
        {
            foreach (var service in services)
            {
                if(service.GetTypeService == typeService)
                {
                    if (service.GetIsFree)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Service GetFreeService(TypeService typeService)
        {
            foreach(var service in services)
            {
                if (service.GetTypeService == typeService)
                {
                    if (service.GetIsFree)
                    {
                        return service;
                    }
                }
            }

            Debug.Log($"<color=red>Not service! But CheckFreeService say TRUE!</color>");
            return null;
        }
    }
}