using System;
using System.Collections.Generic;
using System.Text;

namespace TMKLibrary.Core.Exceptions
{
    public class TMKException : Exception
    {
        public int ErrorCode { get; }

        public int? DeviceNumber { get; }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKException"/>
        /// </summary>
        public TMKException() : base("Произошла ошибка TMK библиотеки")
        {
            ErrorCode = 0;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKException"/> с указанным сообщением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public TMKException(string message)
            : base(message)
        {
            ErrorCode = 0;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKException"/> с указанным сообщением и кодом ошибки
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        public TMKException(string message, int errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKException"/> с указанным сообщением, кодом ошибки и номером устройства
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        /// <param name="deviceNumber">Номер устройства</param>
        public TMKException(string message, int errorCode, int deviceNumber)
            : base(message)
        {
            ErrorCode = errorCode;
            DeviceNumber = deviceNumber;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKException"/> с указанным сообщением и внутренним исключением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public TMKException(string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = 0;
        }

        /// <summary>
        /// Возвращает строковое представление исключения
        /// </summary>
        public override string ToString()
        {
            var result = base.ToString();

            if (ErrorCode != 0)
            {
                result += $"\nТМК Error Code: {ErrorCode}";
            }

            if (DeviceNumber.HasValue)
            {
                result += $"\nDevice Number: {DeviceNumber.Value}";
            }

            return result;
        }





    }
}
