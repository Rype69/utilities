// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectCollection.cs" company="Inspire IT Ltd">
//   Copyright © Ryan Penfold. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Windows.Forms.CheckedListBox
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides extension methods for the <see cref="System.Windows.Forms.CheckedListBox.ObjectCollection"/> type.
    /// </summary>
    public static class ObjectCollection
    {
        /// <summary>
        /// Finds all the items in a <see cref="System.Windows.Forms.CheckedListBox"/> that are checked and have non-null values
        /// </summary>
        /// <param name="checkedListBox">A <see cref="System.Windows.Forms.CheckedListBox"/> to operate on. </param>
        /// <returns>All the items in a <see cref="System.Windows.Forms.CheckedListBox"/> that are checked and have non-null values.</returns>
        public static IEnumerable<string> GetNonNullCheckedItemValues(this System.Windows.Forms.CheckedListBox checkedListBox)
        {
            for (var id = 0; id <= (checkedListBox.Items.Count - 1); id++)
            {
                if (!checkedListBox.GetItemChecked(id))
                {
                    continue;
                }

                var selectedItemString = checkedListBox.Items[id]?.ToString();
                if (string.IsNullOrWhiteSpace(selectedItemString))
                {
                    continue;
                }

                yield return selectedItemString;
            }
        }
    }
}
