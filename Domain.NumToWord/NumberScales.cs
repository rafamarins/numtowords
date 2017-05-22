using System.Collections.Generic;

namespace NumToWord.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class NumberScales
    {
        /// <summary>
        /// 
        /// </summary>
        public struct CustomPair
        {
            /// <summary>
            /// The key
            /// </summary>
            public int Key;
            /// <summary>
            /// The value
            /// </summary>
            public string Value;
        }

        /// <summary>
        /// The units
        /// </summary>
        public static List<CustomPair> UNITS = new List<CustomPair>() {
            new CustomPair(){ Key = 1, Value = "One"},
            new CustomPair(){ Key = 2, Value ="Two"},
            new CustomPair(){ Key = 3, Value ="Three"},
            new CustomPair(){ Key = 4, Value ="Four"},
            new CustomPair(){ Key = 5, Value ="Five"},
            new CustomPair(){ Key = 6, Value ="Six"},
            new CustomPair(){ Key = 7, Value ="Seven"},
            new CustomPair(){ Key = 8, Value ="Eight"},
            new CustomPair(){ Key = 9, Value ="Nine"},
        };

        /// <summary>
        /// The bind
        /// </summary>
        public static string BIND = "And ";
        /// <summary>
        /// The currencybig
        /// </summary>
        public static string CURRENCYBIG = "Dollar";
        /// <summary>
        /// The currencysmall
        /// </summary>
        public static string CURRENCYSMALL = "Cent";
        /// <summary>
        /// The space
        /// </summary>
        public static char SPACE = ' ';
        /// <summary>
        /// The separator
        /// </summary>
        public static char SEPARATOR = ',';

        /// <summary>
        /// The tens
        /// </summary>
        public static List<CustomPair> TENS = new List<CustomPair>() {
            new CustomPair(){ Key =11,Value = "Eleven"},
            new CustomPair(){ Key =12,Value = "Twelve"},
            new CustomPair(){ Key =13,Value = "Thirteen"},
            new CustomPair(){ Key =14,Value = "Fourteen"},
            new CustomPair(){ Key =15,Value = "Fithteen"},
            new CustomPair(){ Key =16,Value = "Sixteen"},
            new CustomPair(){ Key =17,Value = "Seventeen"},
            new CustomPair(){ Key =18,Value = "Eighteen"},
            new CustomPair(){ Key =19,Value = "Nineteen"}
        };


        /// <summary>
        /// The decimals
        /// </summary>
        public static List<CustomPair> DECIMALS = new List<CustomPair>() {
            new CustomPair(){ Key = 10, Value ="Ten"},
            new CustomPair(){ Key =2, Value ="Twenty"},
            new CustomPair(){ Key =3, Value ="Third"},
            new CustomPair(){ Key =4, Value ="Forty"},
            new CustomPair(){ Key =5, Value ="Fithty"},
            new CustomPair(){ Key =6, Value ="Sixty"},
            new CustomPair(){ Key =7, Value ="Sevety"},
            new CustomPair(){ Key =8, Value ="Eighty"},
            new CustomPair(){ Key =9, Value ="Ninety"}            
        };

        /// <summary>
        /// The more
        /// </summary>
        public static List<CustomPair> MORE = new List<CustomPair>() {
            new CustomPair(){ Key =3, Value ="Hundred"},
            new CustomPair(){ Key =4,Value = "Thousand"},
            new CustomPair(){ Key =7,Value = "Million"},
            new CustomPair(){ Key =10,Value = "Billion"},
            new CustomPair(){ Key =13,Value = "Trillion"}
        };
    }
}