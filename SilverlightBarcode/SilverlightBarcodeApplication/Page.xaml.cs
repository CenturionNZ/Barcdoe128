using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightBarcodeApplication
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            MyCanvas.Background = new SolidColorBrush(Colors.Red);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Me.BarcodeSoftware.Barcode.Barcodes barcode = new Me.BarcodeSoftware.Barcode.Barcodes();
            barcode.BarcodeType = Me.BarcodeSoftware.Barcode.Barcodes.BarcodeEnum.Code39;
            barcode.Data = "19111410";
            barcode.encode();
            string encodedData = barcode.EncodedData;
            MyText.Text = barcode.HumanText;

            int encodedLength = 0;
            for (int x = 0; x < encodedData.Length; x++)
            {
                if (encodedData[x] == 't')
                    encodedLength++;
                else if (encodedData[x] == 'w')
                    encodedLength = encodedLength + 3;
            }

            float barWidth = (float)(this.MyCanvas.Width / encodedLength);

            //if (barWidth < 1)
            //    barWidth = 1;
            float thickWidth = barWidth * 3;
            double incrementWidth = 0;

            int swing = 0;
            for (int x = 0; x < encodedData.Length; x++)
            {
                Brush brush;
                if (swing == 0)
                    brush = new SolidColorBrush(Colors.Black);
                else
                    brush = new SolidColorBrush(Colors.White);

                if (encodedData[x] == 't')
                {
                    Rectangle r = new Rectangle();
                    r.Fill = brush;
                    r.Width = barWidth;
                    r.Height = this.MyCanvas.Height;
                    r.SetValue(Canvas.LeftProperty, incrementWidth);
                    r.SetValue(Canvas.TopProperty, 0.0);
                    MyCanvas.Children.Add(r);
                    incrementWidth = incrementWidth + ((barWidth));
                }
                else if (encodedData[x] == 'w')
                {
                    Rectangle r = new Rectangle();
                    r.Fill = brush;
                    r.Width = 3 * barWidth;
                    r.Height = this.MyCanvas.Height;
                    r.SetValue(Canvas.LeftProperty, incrementWidth);
                    r.SetValue(Canvas.TopProperty, 0.0);
                    MyCanvas.Children.Add(r);
                    incrementWidth = incrementWidth + (3 * (barWidth));
                }

                if (swing == 0)
                    swing = 1;
                else
                    swing = 0;
            }
        }
        
    }
    
}
