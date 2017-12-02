namespace RyanPenfold.Utilities.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSortedValue;

        public SortableBindingList()
        {
        }

        public SortableBindingList(IEnumerable<T> list)
        {
            foreach (object o in list)
            {
                this.Add((T)o);
            }
        }

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => this.isSortedValue;

        ListSortDirection sortDirectionValue;
        PropertyDescriptor sortPropertyValue;

        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction)
        {
            var interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType == null && prop.PropertyType.IsValueType)
            {
                var underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

                if (underlyingType != null)
                {
                    interfaceType = underlyingType.GetInterface("IComparable");
                }
            }

            if (interfaceType != null)
            {
                this.sortPropertyValue = prop;
                this.sortDirectionValue = direction;

                IEnumerable<T> query = this.Items;
                query = direction == ListSortDirection.Ascending ? query.OrderBy(i => prop.GetValue(i)) : query.OrderByDescending(i => prop.GetValue(i));
                var newIndex = 0;
                foreach (object item in query)
                {
                    this.Items[newIndex] = (T)item;
                    newIndex++;
                }

                this.isSortedValue = true;
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            else
            {
                throw new NotSupportedException($"Cannot sort by {prop.Name}. This {prop.PropertyType} does not implement IComparable");
            }
        }

        protected override PropertyDescriptor SortPropertyCore => this.sortPropertyValue;

        protected override ListSortDirection SortDirectionCore => this.sortDirectionValue;
    }
}
