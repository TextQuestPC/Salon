using UnityEngine;
using Data;
using ObjectsOnScene;

namespace Core
{
    [CreateAssetMenu(fileName = "DataController", menuName = "Controllers/DataController")]
    public class DataController : Controller
    {
        [SerializeField] private DataItemUI[] dataItemsUI;

        public DataItemUI GetDataItemUI(TypeItem typeItem)
        {
            foreach (var dataItem in dataItemsUI)
            {
                if(dataItem.TypeItem == typeItem)
                {
                    return dataItem;
                }
            }

            Debug.Log($"<color=red>Not have DataItemUI - {typeItem}</color>");
            return null;
        }
    }
}