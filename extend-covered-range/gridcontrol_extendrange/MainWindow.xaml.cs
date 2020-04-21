﻿using Syncfusion.Windows.Controls.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gridcontrol_extendrange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            grid.Model.RowCount = 10;
            grid.Model.ColumnCount = 9;
            grid.Model.HeaderStyle.Borders.All = new Pen(Brushes.LightGray, 1);
            grid.Model.QueryCellInfo += Model_QueryCellInfo;
            Random random = new Random();
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    grid.Model[i, j].CellValue = ((double)random.Next(2, 18)).ToString();
                }
            }
            grid.Model.CoveredRanges.Add(new CoveredCellInfo(2, 2, 5, 5));
        }
        private void Model_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {
            if (e.Style.RowIndex == 0 && e.Style.ColumnIndex > 0)
                e.Style.CellValue = " Col " + e.Style.ColumnIndex;
            else if (e.Style.ColumnIndex == 0 && e.Style.RowIndex > 0)
                e.Style.CellValue = " Row " + e.Style.RowIndex;
        }
        private void Extend_Click(object sender, RoutedEventArgs e)
        {
            grid.Model.CoveredRanges.Clear();
            grid.InvalidateCells();
            grid.Model.CoveredRanges.Add(new CoveredCellInfo(2, 2, 7, 7));
        }
    }
}
