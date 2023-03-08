﻿using Core;
using InputSystem;
using ObjectsOnScene;
using System.Collections.Generic;
using SystemMove;
using UnityEngine;

namespace Characters
{
    public class Player : Character
    {
        [SerializeField] private GameObject positionItem;
        [SerializeField] private GameObject cameraPosition;

        private List<Item> items = new List<Item>();
        private int maxCountItems = 3;

        public GameObject GetCameraPosition { get => cameraPosition; }

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MovePlayerComponent>();
        }

        public void ChangeAngleMove(float angle)
        {
            if (canMove)
            {
                moveComponent.ChangeRotate(angle);

                cameraPosition.transform.rotation = Quaternion.Euler(cameraPosition.transform.rotation.x, angle, cameraPosition.transform.rotation.z);
            }
        }

        public void StartProcedure()
        {
            canMove = false;
            moveComponent.MoveNow = false;

            ShowAnimation(TypeAnimationCharacter.Work);
        }

        public void EndProcedure()
        {
            canMove = true;

            if (TouchSystem.Instance.GetMouseDown)
            {
                moveComponent.MoveNow = true;

                ShowAnimation(TypeAnimationCharacter.Move);
            }
            else
            {
                ShowAnimation(TypeAnimationCharacter.Idle);
            }
        }

        #region CHECK

        public bool CheckHaveItem(TypeItem typeItem)
        {
            foreach (var item in items)
            {
                if(item.GetTypeItem == typeItem)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckCanGetItem()
        {
            return items.Count < maxCountItems;
        }

        #endregion CHECK

        #region ITEMS

        public void GetItemFromPlace(TypeItem typeItem)
        {
            Item item = BoxControllers.GetController<CreatorController>().CreateItem(typeItem);
            item.transform.position = positionItem.transform.position;
            item.transform.SetParent(positionItem.transform);

            items.Add(item);
        }

        public void RemoveItem(TypeItem typeItem)
        {
            foreach (var item in items)
            {
                if(item.GetTypeItem == typeItem)
                {
                    items.Remove(item);
                    Destroy(item.gameObject);
                    return;
                }
            }

            Debug.Log($"Try delete item. Not have item, type = {typeItem}");
        }

        #endregion ITEMS
    }
}