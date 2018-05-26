// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SeleniumExcelAddIn
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        public SortableBindingList()
        {
        }

        public SortableBindingList(IEnumerable<T> enumerable)
            : base(enumerable.ToList())
        {
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        protected override bool IsSortedCore
        {
            get
            {
                return this.isSorted;
            }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return this.sortDirection;
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return this.sortProperty;
            }
        }

        public SortableBindingList<T> Load(IEnumerable<T> enumeration)
        {
            this.ResetItems(enumeration);

            return this;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            this.isSorted = true;
            this.sortDirection = direction;
            this.sortProperty = prop;

            Func<T, object> predicate = n => n.GetType().GetProperty(prop.Name).GetValue(n, null);

            this.ResetItems(this.sortDirection == ListSortDirection.Ascending
                           ? Items.AsParallel().OrderBy(predicate)
                           : Items.AsParallel().OrderByDescending(predicate));
        }

        protected override void RemoveSortCore()
        {
            this.isSorted = false;
            this.sortDirection = base.SortDirectionCore;
            this.sortProperty = base.SortPropertyCore;
            this.ResetBindings();
        }

        private void ResetItems(IEnumerable<T> items)
        {
            try
            {
                this.RaiseListChangedEvents = false;

                var list = items.ToList();
                this.ClearItems();

                foreach (var item in list)
                {
                    this.Add(item);
                }
            }
            finally
            {
                this.RaiseListChangedEvents = true;
                this.ResetBindings();
            }
        }
    }
}
