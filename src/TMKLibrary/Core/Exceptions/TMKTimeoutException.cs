using System;
using System.Collections.Generic;
using System.Text;

namespace TMKLibrary.Core.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при превышении времени ожидания операции TMK
    /// </summary>
    public class TMKTimeoutException : TMKException
    {
        /// <summary>
        /// Время ожидания в миллисекундах
        /// </summary>
        public int TimeoutMs { get; }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKTimeoutException"/>
        /// </summary>
        public TMKTimeoutException()
            : base("Превышено время ожидания операции TMK")
        {
            TimeoutMs = 0;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKTimeoutException"/> с указанным сообщением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public TMKTimeoutException(string message)
            : base(message)
        {
            TimeoutMs = 0;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKTimeoutException"/> с указанным сообщением и временем ожидания
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="timeoutMs">Время ожидания в миллисекундах</param>
        public TMKTimeoutException(string message, int timeoutMs)
            : base(message)
        {
            TimeoutMs = timeoutMs;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKTimeoutException"/> с указанным сообщением, кодом ошибки и временем ожидания
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="errorCode">Код ошибки TMK</param>
        /// <param name="timeoutMs">Время ожидания в миллисекундах</param>
        public TMKTimeoutException(string message, int errorCode, int timeoutMs)
            : base(message, errorCode)
        {
            TimeoutMs = timeoutMs;
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TMKTimeoutException"/> с указанным сообщением и внутренним исключением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public TMKTimeoutException(string message, Exception innerException)
            : base(message, innerException)
        {
            TimeoutMs = 0;
        }

        /// <summary>
        /// Возвращает строковое представление исключения
        /// </summary>
        public override string ToString()
        {
            var result = base.ToString();

            if (TimeoutMs > 0)
            {
                result += $"\nTimeout: {TimeoutMs} ms";
            }

            return result;
        }
    }
}
