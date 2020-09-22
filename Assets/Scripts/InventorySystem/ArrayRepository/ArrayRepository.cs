using System;
using UnityEngine;
using Utility;

namespace InventorySystem.ArrayRepository {
  
  public class ArrayRepository : IItemsRepositoryStrategy {
    public ArrayRepository(int size) {
      _itemsArray = new Item[size];
      _isEmptySlot = new bool[size];
      for (var i = 0; i < size; ++i) {
        _isEmptySlot[i] = true;
        _itemsArray[i] = null;
      }
    }

    public void AddItem(Item item) {
      for (var i = 0; i < _itemsArray.Length; ++i)
        if (_isEmptySlot[i]) {
          _isEmptySlot[i] = false;
          _itemsArray[i] = item;
          return;
        }
    }

    public void RemoveItem(Identifier identifier) {
      for (var i = 0; i < _itemsArray.Length; ++i) {
        if (_isEmptySlot[i])
          continue;
        if (identifier.EqualsTo(_itemsArray[i].GetIdentifier())) {
          _itemsArray[i] = null;
          _isEmptySlot[i] = true;
          return;
        }
      }
    }

    public Item GetItem(Identifier identifier) {
      for (var i = 0; i < _itemsArray.Length; ++i) {
        if (_isEmptySlot[i])
          continue;
        if (identifier.EqualsTo(_itemsArray[i].GetIdentifier())) {
          return _itemsArray[i];
        }
      }
      return null;
    }

    public Item GetItemByIndex(int i) {
      return _itemsArray[i];
    }
    
    public int GetSize() {
      return _itemsArray.Length;
    }

    public IItemIterator GetIterator() {
      return new ArrayRepositoryIterator(this);
    }
    
    
    private Item[] _itemsArray;
    private bool[] _isEmptySlot;
  }
}