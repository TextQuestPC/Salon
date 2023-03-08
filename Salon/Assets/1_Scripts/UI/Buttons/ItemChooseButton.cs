using UnityEngine;
using UnityEngine.UI;
using ObjectsOnScene;
using UI.Buttons;

namespace UI
{
    public class ItemChooseButton : MyButton
    {
        private StorageWindow storageWindow;
        private Image imageItem;
        private TypeItem typeItem;

        protected override void AfterClick()
        {
            storageWindow.OnClickButtonItem(typeItem);
        }

        public void SetDataItemUI(StorageWindow storageWindow, TypeItem typeItem, Sprite sprite)
        {
            this.storageWindow = storageWindow;
            this.typeItem = typeItem;

            if(imageItem == null)
            {
                imageItem = GetComponent<Image>();
            }

            imageItem.sprite = sprite;
        }
    }
}
