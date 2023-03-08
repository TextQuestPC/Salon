using Characters;
using Core;
using UnityEngine;
using UI;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class Storage : InteractionObject
    {
        [SerializeField] private TypeService typeService;
        [SerializeField] private TypeItem typeItem;

        public TypeService GetTypeService { get => typeService; }

        protected override void PlayerInCollider(Player player)
        {
            UIManager.Instance.GetWindow<StorageWindow>().SetDataButtons(new TypeItem[] { typeItem });
            UIManager.Instance.ShowWindow<StorageWindow>();
        }

        protected override void PlayerOutCollider(Player player)
        {
            UIManager.Instance.HideWindow<StorageWindow>();
        }
    }
}