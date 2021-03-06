#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Series_Demo
{
    public class DataGenerator : INotifyPropertyChanged
    {
        public int DataCount = 500;
        private Random randomNumber;
        public event PropertyChangedEventHandler PropertyChanged;
        private string  timeTaken;
               
        public string TimeTaken
        {
            get 
            {
                return timeTaken; 
            }

            set
            { 
                timeTaken = value;
                OnPropertyChanged("TimeTaken");
            }
        }

        public bool IsRunning { get; set; }

        public DateTime StartTime { get; set; }
        
        public DataGenerator()
        {
            randomNumber = new Random();            
        }

        public IList<Data> GenerateData()
        {
            List<Data> datas = new List<Data>();

            DateTime date = new DateTime(2009, 1, 1);
            double value = 1000;

            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new Data(date, value));
                date = date.Add(TimeSpan.FromSeconds(5));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
