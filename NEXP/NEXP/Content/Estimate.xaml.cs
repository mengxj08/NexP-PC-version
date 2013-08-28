﻿using System;
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

namespace NEXP.Content
{
    /// <summary>
    /// Interaction logic for Estimate.xaml
    /// </summary>
    public partial class Estimate : UserControl
    {
        public Estimate()
        {
            InitializeComponent();

            BindingProcess();
        }
        private void BindingProcess()
        {
            trial.DataContext = NEXP.MainWindow.datas.arrangement;
            block.DataContext = NEXP.MainWindow.datas.arrangement;
            timePerTrial.DataContext = NEXP.MainWindow.datas.arrangement;
            minNum.DataContext = NEXP.MainWindow.datas.arrangement;
            actualNum.DataContext = NEXP.MainWindow.datas.arrangement;
            feePerParticipant.DataContext = NEXP.MainWindow.datas.arrangement;
            totalpayment.DataContext = NEXP.MainWindow.datas.arrangement;
            totaltimecost.DataContext = NEXP.MainWindow.datas.arrangement;
        }
        private void Windows_Loaded(object sender, RoutedEventArgs e)
        { 
            //Caluculate the minNum of participants
            int tmp = 1;

            foreach (var idv in MainWindow.datas.independentVariables)
            {
                // Collect name of levels of idv.
                List<string> levelsName = new List<string>();
                foreach (var level in idv.levels)
                {
                    levelsName.Add(level.name);
                }

                switch (idv.counterBalance)
                {
                    case COUNTERBALANCE.FullyCounterBalancing:

                        // Generate permutation.
                        int n = 0;
                        foreach (var i in Utils.GenerateSimulation.Permutate(levelsName, levelsName.Count))
                        {
                            n++;
                        }
                        tmp *= n;
                        break;

                    case COUNTERBALANCE.LatinSquare:

                        tmp *= levelsName.Count;
                        break;

                    case COUNTERBALANCE.NoCounterBalancing:

                        break;
                }
            }

            MainWindow.datas.arrangement.minNum = tmp;
        }
    }
}
