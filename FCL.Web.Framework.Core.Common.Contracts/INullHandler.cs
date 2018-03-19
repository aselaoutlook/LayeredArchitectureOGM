#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Web.Framework.Core.Common.Contracts
///MODULE        :         
///SUB MODULE    :    
///Class         : INullHandler
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Provide an interface to FCL.Web.Framework.Core.Common.NullHandler.INullHandler
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using System;
namespace FCL.Web.Framework.Core.Common.Contracts
{
    public interface INullHandler
    {
        object AvoidNull(object Value);
        bool AvoidNullBool(object Value);
        byte AvoidNullByte(object Value);
        object AvoidNullByteArray(object Value);
        byte? AvoidNullByteNullable(object Value);
        char AvoidNullChar(object Value);
        DateTime AvoidNullDateTime(object objValue);
        DateTime? AvoidNullDateTimeNullable(object objValue);
        DateTime? AvoidNullDateTimeNullable(string value);
        decimal AvoidNullDecimal(object Value);
        double AvoidNulldouble(object Value);
        int AvoidNullint(object Value);
        int? AvoidNullIntNullable(object Value);
        short AvoidNullShort(object Value);
        short? AvoidNullShortNullable(object Value);
        float AvoidNullSingle(object Value);
        float AvoidNullSingleCurrency(object Value);
        string AvoidNullStr(object Value);
        byte ConvertToByte(string value);
        byte? ConvertToByteNullable(string value);
        byte? ConvertToByteNullableZeroNull(string value);
        DateTime? ConvertToDateTimeNullable(object value);
        DateTime? ConvertToDateTimeNullable(string value);
        decimal? ConvertToDecimalNullable(object value);
        decimal? ConvertToDecimalNullable(string value);
        double? ConvertToDoubleNullable(object value);
        double? ConvertToDoubleNullable(string value);
        int ConvertToInt(string value);
        int? ConvertToIntNullable(object value);
        int? ConvertToIntNullable(string value);
        int? ConvertToIntNullableZeroNull(string value);
        long? ConvertToLongNullable(object value);
        short ConvertToShort(string value);
        short? ConvertToShortNullable(string value);
        short? ConvertToShortNullableZeroNull(string value);
        object GetDBNull(DateTime Value);
        object GetDBNull(DateTime? Value);
        string GetShortDateStr(DateTime? value);
        string LeadingZero(int number, int noOfDigits);
        bool NullHandlerForBoolean(object obj, bool alternate);
        DateTime NullHandlerForDate(object obj, DateTime alternate);
        decimal NullHandlerForDecimal(object obj, decimal alternate);
        double NullHandlerForDouble(object obj, double alternate);
        int NullHandlerForInt(object obj, int alternate);
        long NullHandlerForLong(object obj, long alternate);
        short NullHandlerForShort(object obj, short alternate);
        string NullHandlerForString(object obj, string alternate);
        DateTime SetMinimumdate();
        string TextOf(bool Value);
        object ValueOF(bool Value);
        object ValueOF(double Value);
        object ValueOF(int Value);
        object ValueOF(DateTime? Value);
        object ValueOF(int? Value);
        object ValueOF(string Value);
    }
}
