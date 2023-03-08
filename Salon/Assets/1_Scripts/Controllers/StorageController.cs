using System.Collections.Generic;
using ObjectsOnScene;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "StorageController", menuName = "Controllers/StorageController")]
    public class StorageController : Controller
    {
        private List<Storage> storages = new List<Storage>();

        public override void OnInitialize()
        {
            storages.Add(BoxControllers.GetController<CreatorController>().CreateStorage(TypeService.Haircut));
            storages.Add(BoxControllers.GetController<CreatorController>().CreateStorage(TypeService.Brows));
            storages.Add(BoxControllers.GetController<CreatorController>().CreateStorage(TypeService.Nails));
        }
    }
}