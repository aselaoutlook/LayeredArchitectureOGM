#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Web.Framework.Core.Common.NullHandler
///MODULE        :         
///SUB MODULE    :    
///Class         : NullHandler
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : NullHandlers for genaral functios
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using FCL.Web.Framework.Core.Common.Contracts;
using System;
using System.ComponentModel.Composition;

namespace FCL.Web.Framework.Core.Common.NullHandler
{
    [Export(typeof(INullHandler))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class NullHandler : INullHandler
    {
        public NullHandler()
        {
        }

        #region Public Methods
        #region LeadingZero

        /// <summary>
        /// Get Leading Zero(s) for given number of digit
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="noOfDigits">No Of Digits</param>
        /// <returns>String with appropriate leading zeros</returns>
        public string LeadingZero(int number, int noOfDigits)
        {
            double tempNo;
            string tempString;

            tempNo = number / Math.Pow(10, (double)noOfDigits);

            tempString = tempNo.ToString();
            if (tempString == "0.1") tempString = "0.10";
            return tempString.Substring(tempString.IndexOf('.') + 1, noOfDigits);
        }

        #endregion

        #region DateTime SetMinimumdate()
        public DateTime SetMinimumdate()
        {
            return new DateTime(1900, 1, 1, 0, 0, 0);
        }
        #endregion

        #region object ValueOF(string Value)
        public object ValueOF(string Value)
        {
            if (Value == "" || Value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return Value.TrimEnd();
            }
        }
        #endregion

        #region object ValueOF(bool Value)
        public object ValueOF(bool Value)
        {
            if (Value.Equals(null))
            {
                return false;
            }
            else
            {
                return Value;
            }
        }
        #endregion

        #region object ValueOF(int Value)
        public object ValueOF(int Value)
        {
            if (Value.Equals(null))
            {
                return DBNull.Value;
            }
            else
            {
                return Value;
            }
        }
        #endregion

        #region object ValueOF(int? Value)
        public object ValueOF(int? Value)
        {
            if (Value.Equals(null))
            {
                return DBNull.Value;
            }
            else
            {
                return Value;
            }
        }
        #endregion

        #region object ValueOF(double Value)
        public object ValueOF(double Value)
        {
            if (Value.Equals(null))
            {
                return DBNull.Value;
            }
            else
            {
                return Value;
            }
        }
        #endregion

        #region object ValueOF(DateTime? Value)
        public object ValueOF(DateTime? Value)
        {
            if (Value.Equals(null))
            {
                return DBNull.Value;
            }
            else
            {
                return Value;
            }
        }
        #endregion

        #region object AvoidNull(object Value)
        public object AvoidNull(object Value)
        {
            if (Value == DBNull.Value) return null;
            else return Value;
        }
        #endregion

        #region string AvoidNullStr(object Value)
        /// <summary>
        /// Convert and trim string databse object
        /// </summary>
        /// <param name="Value"></param>
        /// <returns>string value</returns>
        public string AvoidNullStr(object Value)
        {
            if ((Value == null) || (Value == DBNull.Value)) return String.Empty;
            else return Convert.ToString(Value).Trim();
        }
        #endregion

        #region char AvoidNullChar(object Value)
        /// <summary>
        /// Convert and char database object
        /// </summary>
        /// <param name="Value"></param>
        /// <returns>char value</returns>
        public char AvoidNullChar(object Value)
        {
            if ((Value == null) || (Value == DBNull.Value)) return Char.MinValue;
            else return ((char)Value);
        }
        #endregion

        #region object AvoidNullByteArray(object Value)
        public object AvoidNullByteArray(object Value)
        {
            if (Value == DBNull.Value) return new byte[0];
            else return Value;
        }
        #endregion

        #region bool AvoidNullBool(object Value)
        public bool AvoidNullBool(object Value)
        {
            if (Value == DBNull.Value || Value.ToString() == String.Empty) return false;
            else return (bool)Value;
        }
        #endregion

        #region int AvoidNullint(object Value)
        public int AvoidNullint(object Value)
        {
            if (Value == DBNull.Value || Value.ToString() == String.Empty) return 0;
            else return int.Parse(Value.ToString());
        }
        #endregion

        public int? AvoidNullIntNullable(object Value)
        {
            if (Value == DBNull.Value || Value.ToString() == String.Empty) return null;
            else return ConvertToIntNullable(Value.ToString());
        }

        public byte AvoidNullByte(object Value)
        {
            if (Value == DBNull.Value) return 0;
            else return ConvertToByte(Value.ToString());
        }

        public byte? AvoidNullByteNullable(object Value)
        {
            if (Value == DBNull.Value) return null;
            else return ConvertToByteNullable(Value.ToString());
        }

        public short AvoidNullShort(object Value)
        {
            if (Value == DBNull.Value) return 0;
            else return ConvertToByte(Value.ToString());
        }

        public short? AvoidNullShortNullable(object Value)
        {
            if (Value == DBNull.Value) return null;
            else return ConvertToShortNullable(Value.ToString());
        }

        #region decimal AvoidNullDecimal(object Value)
        public decimal AvoidNullDecimal(object Value)
        {
            if (Value == DBNull.Value || Value.ToString() == String.Empty) return 0;
            else return decimal.Parse(Value.ToString());
        }
        #endregion

        #region Single AvoidNullSingle(object Value)
        public Single AvoidNullSingle(object Value)
        {
            if (Value == DBNull.Value) return 0;
            else return Single.Parse(Value.ToString());
        }
        #endregion

        #region Single AvoidNullSingleCurrency(object Value)
        public Single AvoidNullSingleCurrency(object Value)
        {
            if (Value == DBNull.Value) return 0;
            else
            {
                Single s = Single.Parse(Value.ToString());
                return Single.Parse(s.ToString("#,###.00"));

            }
        }
        #endregion

        #region double AvoidNulldouble(object Value)
        public double AvoidNulldouble(object Value)
        {
            if (Value == DBNull.Value) return 0;
            else return double.Parse(Value.ToString());
        }
        #endregion

        #region DateTime AvoidNullDateTime(object objValue)
        public DateTime AvoidNullDateTime(object objValue)
        {
            if (objValue == DBNull.Value)
            {
                DateTime dateTime = new DateTime();
                dateTime = DateTime.MinValue;
                return dateTime;

            }
            else return (DateTime)objValue;
        }
        #endregion

        #region DateTime? AvoidNullDateTime(object objValue)
        public DateTime? AvoidNullDateTimeNullable(object objValue)
        {
            if (objValue == DBNull.Value)
            {
                return null;
            }
            else return (DateTime)objValue;
        }
        #endregion

        #region string TextOf(bool Value)
        public string TextOf(bool Value)
        {
            if (Value)
                return "Yes";
            else
                return "No";
        }
        #endregion

        #region object GetDBNull(DateTime Value)
        public object GetDBNull(DateTime Value)
        {
            if (Value == SetMinimumdate()) return DBNull.Value;
            else return Value;

        }

        #endregion

        #region object GetDBNull(DateTime? Value)
        public object GetDBNull(DateTime? Value)
        {
            if (Value == null) return DBNull.Value;
            else return Value;

        }

        #endregion

        #region int ConvertToInt(string value)
        public int ConvertToInt(string value)
        {
            int i = 0;
            int.TryParse(value, out i);
            return i;
        }
        #endregion

        #region int? ConvertToIntNullable(string value)
        public int? ConvertToIntNullable(string value)
        {
            if (value == null || value == "")
            {
                return null;
            }
            else
            {
                return ConvertToInt(value);
            }
        }

        public int? ConvertToIntNullable(object value)
        {
            if (value == null || value.ToString() == "")
            {
                return null;
            }
            else
            {
                return ConvertToInt(value.ToString());
            }
        }
        #endregion

        #region int? ConvertToIntNullableZeroNull(string value)
        public int? ConvertToIntNullableZeroNull(string value)
        {
            if (value == null || value == "" || value == "0")
            {
                return null;
            }
            else
            {
                return ConvertToInt(value);
            }
        }
        #endregion

        #region DateTime? ConvertToDateTimeNullable(string value)
        public DateTime? ConvertToDateTimeNullable(string value)
        {
            if (value == null || value == "")
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(value);
            }
        }
        public DateTime? ConvertToDateTimeNullable(object value)
        {
            if (value == null || value.ToString() == String.Empty)
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(value);
            }
        }
        #endregion

        #region Double? ConvertToDoubleNullable(string value)
        public Double? ConvertToDoubleNullable(string value)
        {
            if (value == null || value == "")
            {
                return null;
            }
            else
            {
                return Convert.ToDouble(value);
            }
        }
        #endregion

        #region Double? ConvertToDoubleNullable(object value)
        public Double? ConvertToDoubleNullable(object value)
        {
            if (value == null || value.ToString() == "")
            {
                return null;
            }
            else
            {
                return Convert.ToDouble(value.ToString());
            }
        }
        #endregion

        #region Long? ConvertToLongNullable(object value)
        public long? ConvertToLongNullable(object value)
        {
            if (value == null || value.ToString() == "")
            {
                return null;
            }
            else
            {
                return Convert.ToInt64(value.ToString());
            }
        }
        #endregion

        #region Decimal? ConvertToDecimalNullable(string value)
        public Decimal? ConvertToDecimalNullable(string value)
        {
            if (value == null || value == "")
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(value);
            }
        }

        public Decimal? ConvertToDecimalNullable(object value)
        {
            if (value == null || value.ToString() == string.Empty)
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(value);
            }
        }
        #endregion

        public byte ConvertToByte(string value)
        {
            byte i = 0;
            byte.TryParse(value, out i);
            return i;
        }

        #region byte? ConvertToByteNullable(string value)
        public byte? ConvertToByteNullable(string value)
        {
            if (value == null || value == "")
            {
                return null;
            }
            else
            {
                return ConvertToByte(value);
            }
        }
        #endregion

        #region byte? ConvertToByteNullableZeroNull(string value)
        public byte? ConvertToByteNullableZeroNull(string value)
        {
            if (value == null || value == "" || value == "0")
            {
                return null;
            }
            else
            {
                return ConvertToByte(value);
            }
        }
        #endregion

        public short ConvertToShort(string value)
        {
            short i = 0;
            short.TryParse(value, out i);
            return i;
        }

        #region short? ConvertToShortNullable(string value)
        public short? ConvertToShortNullable(string value)
        {
            if (value == null || value == "")
            {
                return null;
            }
            else
            {
                return ConvertToShort(value);
            }
        }
        #endregion

        #region short? ConvertToShortNullableZeroNull(string value)
        public short? ConvertToShortNullableZeroNull(string value)
        {
            if (value == null || value == "" || value == "0")
            {
                return null;
            }
            else
            {
                return ConvertToShort(value);
            }
        }
        #endregion

        #region DateTime? AvoidNullDateTimeNullable(string value)
        public DateTime? AvoidNullDateTimeNullable(string value)
        {
            if (value == null || value == "")
            {
                return null;
            }
            else return DateTime.Parse(value);
        }
        #endregion

        #region string GetShortDateStr(DateTime? value)
        public string GetShortDateStr(DateTime? value)
        {
            if (value == null)
            {
                return "";
            }
            else return DateTime.Parse(value.ToString()).ToShortDateString();
        }
        #endregion

        public string NullHandlerForString(object obj, string alternate)
        {
            try
            {
                if (obj == null || obj.ToString() == string.Empty)
                    return alternate;
                else
                    return Convert.ToString(obj);
            }
            catch (Exception)
            {

                return alternate;
            }
        }

        public int NullHandlerForInt(object obj, int alternate)
        {
            try
            {
                if (obj == null || obj.ToString() == string.Empty)
                    return alternate;
                else
                    return Convert.ToInt32(obj);
            }
            catch (Exception)
            {

                return alternate;
            }
        }

        public short NullHandlerForShort(object obj, short alternate)
        {
            try
            {
                if (obj == null || obj.ToString() == string.Empty)
                    return alternate;
                else
                    return Convert.ToInt16(obj);
            }
            catch (Exception)
            {

                return alternate;
            }
        }

        public decimal NullHandlerForDecimal(object obj, decimal alternate)
        {
            try
            {
                if (obj == null || obj.ToString() == string.Empty)
                    return alternate;
                else
                {
                    decimal outVal;
                    if (decimal.TryParse(obj.ToString(), out outVal))
                        return outVal;
                    else
                        return alternate;
                }
            }
            catch (Exception)
            {

                return alternate;
            }
        }

        public double NullHandlerForDouble(object obj, double alternate)
        {
            try
            {
                if (obj == null || obj.ToString() == string.Empty)
                    return alternate;
                else
                    return Convert.ToDouble(obj);
            }
            catch (Exception)
            {

                return alternate;
            }
        }

        public long NullHandlerForLong(object obj, long alternate)
        {
            try
            {
                if (obj == null || obj.ToString() == string.Empty)
                    return alternate;
                else
                    return Convert.ToInt64(obj);
            }
            catch (Exception)
            {

                return alternate;
            }
        }

        public DateTime NullHandlerForDate(object obj, DateTime alternate)
        {
            try
            {
                if (obj == null || obj.ToString() == string.Empty)
                    return alternate;
                else
                    return Convert.ToDateTime(obj);
            }
            catch (Exception)
            {

                return alternate;
            }
        }

        public bool NullHandlerForBoolean(object obj, bool alternate)
        {
            try
            {
                if (obj == null || obj.ToString() == string.Empty)
                    return alternate;
                else
                    return Convert.ToBoolean(obj);
            }
            catch (Exception)
            {

                return alternate;
            }
        }


        #endregion
    }
}
