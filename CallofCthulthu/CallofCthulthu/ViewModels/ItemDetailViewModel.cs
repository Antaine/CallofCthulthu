﻿using System;

using CallofCthulthu.Models;

namespace CallofCthulthu.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Name;
            Item = item;
        }
    }
}
