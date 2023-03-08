using UnityEngine;
using ObjectsOnScene;
using Data;
using Core;
using UI.Windows;

namespace UI
{
    public class StorageWindow : Window
    {
        [HideInInspector]
        public delegate void ChooseItem();
        public event ChooseItem AfterChooseItem;

        [SerializeField] private ItemChooseButton[] itemButtons;

        public void SetDataButtons(TypeItem[] typeItems)
        {
            for (int i = 0; i < typeItems.Length; i++)
            {
                DataItemUI data = BoxControllers.GetController<DataController>().GetDataItemUI(typeItems[i]);

                itemButtons[i].gameObject.SetActive(true);
                itemButtons[i].SetDataItemUI(this, typeItems[i], data.SpriteItem);
            }
        }

        public void OnClickButtonItem(TypeItem typeItem)
        {
            BoxControllers.GetController<GameController>().PlayerTryGetItem(typeItem);

            Hide();
        }

        public override void Hide()
        {
            foreach (var button in itemButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}