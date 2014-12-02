﻿

using System;
using System.Collections.Generic;
using System.Text;

namespace Me.BarcodeSoftware.Barcode
{  
    public class Barcodes
    {
   

        public enum YesNoEnum
        {
            Yes,
            No
        }

        public enum BarcodeEnum
        {
            Code39
        }

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        private string data;

        public BarcodeEnum BarcodeType
        {
            get { return barcodeType; }
            set { barcodeType = value; }
        }
        private BarcodeEnum barcodeType;

        public YesNoEnum CheckDigit
        {
            get { return checkDigit; }
            set { checkDigit = value;}
        }
        private YesNoEnum checkDigit;

        public string HumanText
        {
            get {
                return humanText; 
            }
            set { humanText = value; }
        }
        private string humanText;

        public string EncodedData
        {
            get { return encodedData; }
            set { encodedData = value; }
        }
        private string encodedData;

        public void encode()
        {
            int check=0;
            if (checkDigit == Barcodes.YesNoEnum.Yes)
                check = 1;

            //if (barcodeType == BarcodeEnum.Code39)
            //{
            //    Code39 barcode = new Code39();
            //    encodedData = barcode.encode(data, check);
            //    humanText = barcode.getHumanText();
            //}

            if (barcodeType == BarcodeEnum.Code39)
            {
                Code128 barcode = new Code128(data, Code128.TYPES.A);
                var binaryEncodedData = barcode.Encoded_Value;
                humanText = barcode.RawData;

                encodedData = ConvertBinaryDataToEncodedData(binaryEncodedData);
            }
        }

        private string ConvertBinaryDataToEncodedData(string binaryData)
        {
            string convertedData = binaryData.Replace('0', 't');
            convertedData = convertedData.Replace('1', 'w');

            return convertedData;
        }
    }

    
   
    
}
