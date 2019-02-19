﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestCompletionItem
    {
        public Item Details { get; set; }
        public int RequiredAmount { get; set; }
        public int Quantity { get; set; }

        public QuestCompletionItem(Item details, int requiredAmount)
        {
            Details = details;
            RequiredAmount = requiredAmount;
        }
    }
}
