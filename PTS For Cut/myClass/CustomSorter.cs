namespace PTS_For_Cut.myClass
{
    internal class CustomSorter
    {
        private int columnIndex;
        private bool ascending;

        public CustomSorter(int columnIndex, bool ascending)
        {
            this.columnIndex = columnIndex;
            this.ascending = ascending;
        }

        public int Compare(object x, object y)
        {
            DataGridViewRow rowX = x as DataGridViewRow;
            DataGridViewRow rowY = y as DataGridViewRow;

            object cellX = rowX?.Cells[columnIndex].Value;
            object cellY = rowY?.Cells[columnIndex].Value;

            // Handle null values
            if (cellX == DBNull.Value || cellX == null) return ascending ? 1 : -1;
            if (cellY == DBNull.Value || cellY == null) return ascending ? -1 : 1;

            // Convert to string and compare
            return ascending
                ? string.Compare(cellX.ToString(), cellY.ToString())
                : string.Compare(cellY.ToString(), cellX.ToString());
        }
    }
}
