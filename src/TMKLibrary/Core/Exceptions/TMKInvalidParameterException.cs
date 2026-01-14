using System;
using System.Collections.Generic;
using System.Text;

namespace TMKLibrary.Core.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при передаче неверных параметров в методы TMK
    /// </summary>
    public class TMKInvalidParameterException : TMKException
    {
        /// <summary>
        /// Имя неверного параметра
        /// </summary>
        public string? ParameterName { get; }

        /// <summary>
        /// Значение неверного параметра
        /// </summary>
        public object? ParameterValue { get; }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKInvalidParameterException"/>
        /// </summary>
        public TMKInvalidParameterException()
            : base("Передан неверный параметр")
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKInvalidParameterException"/> с указанным сообщением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public TMKInvalidParameterException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKInvalidParameterException"/> с указанным сообщением и кодом ошибки
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        public TMKInvalidParameterException(string message, int errorCode)
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKInvalidParameterException"/> с указанным сообщением, кодом ошибки и номером устройства
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        /// <param name="deviceNumber">Номер устройства</param>
        public TMKInvalidParameterException(string message, int errorCode, int deviceNumber)
            : base(message, errorCode, deviceNumber)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKInvalidParameterException"/> с указанным параметром
        /// </summary>
        /// <param name="parameterName">Имя параметра</param>
        /// <param name="message">Сообщение об ошибке</param>
        public TMKInvalidParameterException(string parameterName, string message)
            : base($"Неверный параметр '{parameterName}': {message}")
        {
            ParameterName = parameterName;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKInvalidParameterException"/> с указанным параметром и значением
        /// </summary>
        /// <param name="parameterName">Имя параметра</param>
        /// <param name="parameterValue">Значение параметра</param>
        /// <param name="message">Сообщение об ошибке</param>
        public TMKInvalidParameterException(string parameterName, object parameterValue, string message)
            : base($"Неверный параметр '{parameterName}' = '{parameterValue}': {message}")
        {
            ParameterName = parameterName;
            ParameterValue = parameterValue;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKInvalidParameterException"/> с указанным сообщением и внутренним исключением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public TMKInvalidParameterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Возвращает строковое представление исключения
        /// </summary>
        public override string ToString()
        {
            var result = base.ToString();

            if (!string.IsNullOrEmpty(ParameterName))
            {
                result += $"\nParameter Name: {ParameterName}";
            }

            if (ParameterValue != null)
            {
                result += $"\nParameter Value: {ParameterValue}";
            }

            return result;
        }
    }
}
