﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CallofCthulthu.Models
{
    public enum MenuItemType
    {
        Home,
        Roll,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
